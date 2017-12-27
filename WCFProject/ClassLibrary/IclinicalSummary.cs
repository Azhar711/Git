using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace ClassLibrary
{
    [ServiceContract]
    interface IclinicalSummary
    {
        
    }

    [DataContract]
    public class CarePlanGoals
    {
        [DataMember]
        public string Goal;

        [DataMember]
        public DateTime StartDate;

        [DataMember]
        public string Priority;

        [DataMember]
        public DateTime EndDate;

    }
}
