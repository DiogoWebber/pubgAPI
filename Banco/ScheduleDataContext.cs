using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScheduleSample.Models
{
    public class ScheduleDataContext : IdentityDbContext<IdentityUser>
    {
        public ScheduleDataContext(DbContextOptions<ScheduleDataContext> options)
            : base(options)
        {
        }

        public DbSet<ScheduleEventData> ScheduleEventDatas { get; set; }

        // Outros DbSets para outras entidades podem ser adicionados aqui.
    }
}