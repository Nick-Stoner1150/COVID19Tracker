using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ProgramUI programUI = new ProgramUI();
            await programUI.Run();

          
        }
    }
}
