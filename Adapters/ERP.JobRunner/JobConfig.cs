using ERP.JobRunner.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.JobRunner
{
    public static class JobConfig
    {
        public static void Start()
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            AddJob<StockJob>(scheduler, TimeSpan.FromSeconds(2000000), DateTime.Now);
            scheduler.Start();
        }

        private static void AddJob<T>(IScheduler scheduler, TimeSpan repeateTimeSpan, DateTime startAt) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(nameof(T), "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"{nameof(T)}Trigger", "group1")
                    .StartAt(startAt)
                    .WithSimpleSchedule(simpleSchedule => simpleSchedule.WithInterval(repeateTimeSpan)
                    .RepeatForever())
                    .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
