using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GreetService" in both code and config file together.
    public class MyService : IMyService
    {
        public string GetMessage(string Name)
        {
            return "Hello " + Name;
        }

        public Student GetStudent(int id)
        {
            Student st= new Student();
            st.id=1;
            st.name="John Doe";
            st.gender="Male";
            st.dob = DateTime.UtcNow;
            return st;
        }

    }

    [DataContract]
    public class Student
    {
        private int Id;
        private string Name;
        private string Gender;
        private DateTime DOB;

        [DataMember(Order=1)]
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember(Order=2)]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        [DataMember(Order=3)]
        public string gender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        [DataMember(Order=4)]
        public DateTime dob
        {
            get { return DOB; }
            set { DOB = value; }
        }
    }

}
