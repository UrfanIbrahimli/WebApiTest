﻿using ERP.RegionStockWindowsService.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ERP.RegionStockWindowsService
{
    public static class JobConfig
    {
        public static void Start()
        {
            int second = Convert.ToInt32(ConfigurationManager.AppSettings["Seconds"]);
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            AddJob<OutcomeToIncomeJob>(scheduler, TimeSpan.FromSeconds(second), DateTime.Now);
            scheduler.Start();
        }

        private static void AddJob<T>(IScheduler scheduler, TimeSpan repeateTimeSpan, DateTime startAt) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(nameof(T), "groupOutcome")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"{nameof(T)}Trigger", "groupOutcome")
                    .StartAt(startAt)
                    .WithSimpleSchedule(simpleSchedule => simpleSchedule.WithInterval(repeateTimeSpan)
                    .RepeatForever())
                    .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
