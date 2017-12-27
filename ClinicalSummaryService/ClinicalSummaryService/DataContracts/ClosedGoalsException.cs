using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClinicalSummaryService
{
    [DataContract]
    public class GoalDetailsResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        
        [DataMember]
        public string Message { get; set; }
        
        [DataMember]
        public List<GoalDetails> Goals { get; set; }
        
    }
}