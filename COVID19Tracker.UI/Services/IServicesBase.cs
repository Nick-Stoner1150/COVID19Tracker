using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI.Services
{
    public interface IServicesBase
    {

        Task Create<T>(string route, T content);
        Task<T> GetById<T>(string route, int id);

        Task<IEnumerable<T>> GetAll<T>(string route);

    }
}
