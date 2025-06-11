using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Survey_System.Models
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {

        }

        public DbSet<SurveyType> SurveyTypes { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public string? SurveyTypeName { get; internal set; }
        public int SurveyTypeID { get; internal set; }
        public string ModifiedBy { get; internal set; }
    }
}
