using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using log4net;

namespace ClinicalSummaryService
{
    public class GoalService : IGoalService
    {
        private Repository repository;
        private static readonly ILog logger = LogManager.GetLogger("");
        public GoalDetailsResponse GetDetails(string memberId, string start_date, string end_date)
        {
            try
            {
                repository = new Repository(ConfigurationManager.ConnectionStrings["ServiceConnection"].ConnectionString);
                var result= repository.GetGoalDetails(memberId,start_date,end_date);
                var response = new GoalDetailsResponse();
                response.Goals = result;
                if(result.Count>0)
                {
                    response.IsSuccess = true;
                    if(!result.Any(r=>r.GoalStatus.Equals("Open", StringComparison.OrdinalIgnoreCase)))
                    {
                        response.Message = "There are No Goals in Open State";
                    }
                }
                else
                {
                    response.Message = "There are no Goals are in Open or Closed Status";
                    response.IsSuccess = true;
                }
                return response;
            }
            catch(Exception ex)
            {
                var respone = new GoalDetailsResponse();
                respone.IsSuccess = false;
                respone.Message = "An Exception has occurred while processing your request";
                return respone;
            }
            
        }
    }
}
