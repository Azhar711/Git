using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using log4net;

namespace ClinicalSummaryService
{
    public class Repository
    {
        private readonly string connectionString;
        private readonly string selectGoalDetails;

        private static readonly ILog logger = LogManager.GetLogger(typeof(Repository));


        private GoalDetails goalDetails;

        public Repository(string connectionString)
        {
            logger.Debug("Log entered Repository, GET select Query");
            this.connectionString = connectionString;
            this.selectGoalDetails = @"SELECT 
                                       distinct G1.GOAL_STATUS ,V1.MEMBER_ID ,G1.* 
                                       FROM 
                                       [JIVA_BI_DB].[dbo].[V_MODEL_GOALS] G1
                                       INNER JOIN 
                                       [JIVA_BI_DB].[dbo].[V_MODEL_MBR_MULTIPLE_IDS] V1 
                                       ON G1.MBR_IDN =V1.MBR_IDN 
                                WHERE
                                       V1.ID_TYPE_CD  = 'ELIG' AND 
                                       V1.MEMBER_ID=@memberId AND
                                       G1.GOAL_START_DATE >=@start_date
                                       AND G1.GOAL_START_DATE <=@end_date 
                                       AND (GOAL_STATUS='Closed' OR GOAL_STATUS='Open')
                                ORDER BY  G1.GOAL_STATUS DESC";

        }

        public List<GoalDetails> GetGoalDetails(string memberId, string start_date, string end_date)
        {
            List<GoalDetails> result = new List<GoalDetails>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectGoalDetails, connection))
                {
                    logger.Info("Executing SQL command for Clinical Summary for Member ID: " + memberId);
                    command.Parameters.AddWithValue("@memberId", memberId);
                    command.Parameters.AddWithValue("@start_date", start_date);
                    command.Parameters.AddWithValue("@end_date", end_date);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                goalDetails = new GoalDetails
                                   {
                                       Goal = GetString(reader["GOAL"]),
                                       AchievedDate = GetDateTime(reader["ACHIEVED_DATE"]),
                                       CompletionDate = GetDateTime(reader["COMPLETION_DATE"]),
                                       GoalPriority = GetString(reader["GOAL_PRIORITY"]),
                                       GoalStartDate = GetDateTime(reader["GOAL_START_DATE"]),
                                       GoalStatus = GetString(reader["GOAL_STATUS"])
                                   };
                                result.Add(goalDetails);
                                logger.Info("Returning data fo the member ID: " + memberId);
                            }
                        }
                        else
                        {
                            goalDetails = new GoalDetails
                            {
                                Goal = "No Goals Open",
                                GoalPriority = "None",
                                GoalStatus = "No Goals in Open Status"
                            };
                            result.Add(goalDetails);
                        }
                    }
                    return result;
                }
            }
        }

        private string GetString(object val)
        {
            if (val == DBNull.Value)
                return null;
            else
                return Convert.ToString(val);
        }

        private DateTime? GetDateTime(object val)
        {
            if (val == DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(val);
        }
    }
}