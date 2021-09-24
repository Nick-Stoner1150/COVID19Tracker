using COVID19Tracker.Data;
using COVID19Tracker.Data.HealthStatus_Data;
using COVID19Tracker.Models.HealthStatus_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Services.HealthStatus_Services
{
    public class HealthStatusService
    {
        public async Task<bool> Post(HealthStatusCreate healthStatus)
        {
            var entity = new HealthStatus
            {
                Vaccinated = healthStatus.Vaccinated,
                HasCovid = healthStatus.HasCovid,
                Hospitalized = healthStatus.Hospitalized,
                Comorbidities = healthStatus.Comorbidities,
                QuarantinedDate = healthStatus.QuarantinedDate,
                LastTestedDate = healthStatus.LastTestedDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HealthStatuses.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Put(HealthStatusEdit healthStatus, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldHealth = await ctx.HealthStatuses.FindAsync(id);
                if (oldHealth is null)
                {
                    return false;
                }

                oldHealth.Vaccinated = healthStatus.Vaccinated;
                oldHealth.HasCovid = healthStatus.HasCovid;
                oldHealth.Hospitalized = healthStatus.Hospitalized;
                oldHealth.Comorbidities = healthStatus.Comorbidities;
                oldHealth.QuarantinedDate = healthStatus.QuarantinedDate;
                oldHealth.LastTestedDate = healthStatus.LastTestedDate;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<HealthStatusDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var healthStatus =
                    await
                    ctx
                    .HealthStatuses
                    .SingleOrDefaultAsync(h => h.HealthStatusId == id);
                if (healthStatus is null)
                {
                    return null;
                }
                return new HealthStatusDetail
                {
                    Vaccinated = healthStatus.Vaccinated,
                    HasCovid = healthStatus.HasCovid,
                    Hospitalized = healthStatus.Hospitalized,
                    Comorbidities = healthStatus.Comorbidities,
                    QuarantinedDate = healthStatus.QuarantinedDate,
                    LastTestedDate = healthStatus.LastTestedDate
                };
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldHealth = await ctx.HealthStatuses.FindAsync(id);

                if (oldHealth is null)
                {
                    return false;
                }
                ctx.HealthStatuses.Remove(oldHealth);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> PostAndPut(HealthStatusCreate healthStatusCreate, int id)
        {

            var entity = new HealthStatus
            {
                Vaccinated = healthStatusCreate.Vaccinated,
                HasCovid = healthStatusCreate.HasCovid,
                Hospitalized = healthStatusCreate.Hospitalized,
                Comorbidities = healthStatusCreate.Comorbidities,
                QuarantinedDate = healthStatusCreate.QuarantinedDate,
                LastTestedDate = healthStatusCreate.LastTestedDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                var oldHealthStatus = await ctx.HealthStatuses.FindAsync(id);
                if (oldHealthStatus is null)
                {
                    return false;
                }

                oldHealthStatus.Vaccinated = healthStatusCreate.Vaccinated;
                oldHealthStatus.HasCovid = healthStatusCreate.HasCovid;
                oldHealthStatus.Hospitalized = healthStatusCreate.Hospitalized;
                oldHealthStatus.Comorbidities = healthStatusCreate.Comorbidities;
                oldHealthStatus.QuarantinedDate = healthStatusCreate.QuarantinedDate;
                oldHealthStatus.LastTestedDate = healthStatusCreate.LastTestedDate;

                ctx.HealthStatuses.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
