using Microsoft.EntityFrameworkCore;
using Snow.DataVisualizer.API.Entities;


namespace Snow.DataVisualizer.API.Repositories.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<FileOutputData> FileOutputDatas { get; set; }
    }
}
