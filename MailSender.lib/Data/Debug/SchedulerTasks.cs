﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Debug
{
    public static class SchedulerTasks
    {
        public static List<SchedulerTask> Items = new List<SchedulerTask>()
        {
                new SchedulerTask()
                {
                        Id = 1, Name = "Task 1", Time = DateTime.Now.AddHours( 1 ), Mail = "MailAddress 1"
                },
                new SchedulerTask()
                {
                        Id = 2, Name = "Task 2", Time = DateTime.Now.AddHours( 2 ), Mail = "MailAddress 2"
                },
                new SchedulerTask()
                {
                        Id = 3, Name = "Task 3", Time = DateTime.Now.AddHours( 3 ), Mail = "MailAddress 3"
                },
        };
    }

    public class SchedulerTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Mail { get; set; }
    }
}