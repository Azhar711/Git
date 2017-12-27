using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ServerName
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = System.Environment.MachineName;
            Console.WriteLine("Your Server Name is {0}",Name);
            Testing();
            Console.ReadKey();
        }

        internal static void Testing()  
        {  
            log4net.Config.BasicConfigurator.Configure();  
            log4net.ILog log = log4net.LogManager.GetLogger(typeof (Program));  
            try  
            {
                log.Info(string.Format("Server Name is  :{0}", Environment.MachineName));
            }  
            catch (Exception ex)  
            {  
                log.Error("Error Message: " + ex.Message.ToString(), ex);  
            }  
        }  

    }

}
