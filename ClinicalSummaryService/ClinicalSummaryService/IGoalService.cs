using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClinicalSummaryService
{
    [ServiceContract]
    public interface IGoalService
    {
        [OperationContract]
        GoalDetailsResponse GetDetails(string memberId, string start_date, string end_date);
    }
}
