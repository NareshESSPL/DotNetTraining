using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp
{
// Create a interface IJob, it has a method called GetSchedule() with ReturnType as Schdeule.

// Schedule should have property ScheduleID and TrigerTime as datetime

// Create another interface called ILocalJob with method Run()

//IJob is parent for ILocalJob

//Create a abstract method called Scheduler extending ILocalJob with constructor to accept a ILogger
//type
    public class Schedule
    {
        public int  ScheduleID { get; set; }
        public DateTime TrigerTime {  get; set; }
    }
    public interface IJobID {
    
        public Schedule GetSchedule()
        {
            return new Schedule();
        }
    }

    public interface ILocalJob : IJobID
    {
        public void Run()
        {
            return ;
        }
    }

    //public delegate  <Schedule> ILogger()


}
