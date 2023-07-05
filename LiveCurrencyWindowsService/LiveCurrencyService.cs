using LiveCurrencyWindowsService.AppCode.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.IO;
using System.ServiceProcess;

namespace LiveCurrencyWindowsService
{
    public partial class LiveCurrencyService : ServiceBase
    {
        readonly string logPath = null;
        IScheduler scheduler = null;
        public LiveCurrencyService()
        {
            InitializeComponent();
            this.logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        }

        protected override  void OnStart(string[] args)
        {
            using (StreamWriter writer = new StreamWriter(logPath,true))
            {
               
                writer.WriteLine($"[{DateTime.Now:yyyy.MM.dd mm.ss.fff}] : I am Running");
            }
            StdSchedulerFactory factory = new StdSchedulerFactory();

            scheduler = factory.GetScheduler().Result;

            JobDataMap jpm = new JobDataMap();
            jpm.Add("logPath", logPath);

            IJobDetail job = JobBuilder.Create<LiveCurrencyJob>()
                .WithIdentity("liveCurrencyJob", "Currency")
                    .SetJobData(jpm)
                        .Build();
            
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("liveCurrencyJob", "Currency")
                    .StartNow()
                        .WithCronSchedule("0 0 * ? * MON,TUE,WED,THU,FRI *")
                            .WithSimpleSchedule(x => x
                                .WithIntervalInSeconds(10)
                                    .RepeatForever())
                                        .Build();

            scheduler.ScheduleJob(job, trigger).Wait();
            scheduler.Start().Wait();
        }

        protected override void OnStop()
        {
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy.MM.dd mm.ss.fff}] : I am Stopping");
            }
            scheduler.Shutdown().Wait();

        }
    }
}
