using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClinicalSummaryService
{
    [DataContract]
    public class GoalDetails
    {
        [DataMember]
        public string Goal { get; set; }
        [DataMember]
        public DateTime? GoalStartDate { get; set; }
        [DataMember]
        public string GoalPriority { get; set; }
        [DataMember]
        public DateTime? CompletionDate { get; set; }
        [DataMember]
        public DateTime? AchievedDate { get; set; }
        [DataMember]
        public string GoalStatus { get; set; }
    }

}