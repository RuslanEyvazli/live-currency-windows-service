using Quartz;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveCurrencyWindowsService.AppCode.Jobs
{
    internal class LiveCurrencyJob : IJob
    {
        readonly HttpClient client;
        public LiveCurrencyJob()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://cbar.az/");
        }
        public async Task Execute(IJobExecutionContext context)
        {

            var logPath = context.JobDetail.JobDataMap.GetString("logPath");
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy.MM.dd mm.ss.fff}] : Executed");
            }



            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:dd.MM.yyyy}.xml");

            if(File.Exists(physicalPath))
            {
                return;
            }

            var remotePath = $"/currencies/{DateTime.Now:dd.MM.yyyy}.xml";

            var response = await client.GetAsync(remotePath);

            if (response.IsSuccessStatusCode)
            {
                string contentXML = await response.Content.ReadAsStringAsync();

                File.WriteAllText(physicalPath, contentXML);
            }
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy.MM.dd mm.ss.fff}] : Successfully Downloaded!");
            }


        }
    }
}
