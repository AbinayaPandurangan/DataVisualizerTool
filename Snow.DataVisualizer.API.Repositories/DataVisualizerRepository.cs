using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Snow.DataVisualizer.API.Entities;
using Snow.DataVisualizer.API.Repositories.DataContexts;
using Snow.DataVisualizer.API.Repositories.Interface;

namespace Snow.DataVisualizer.API.Repositories
{
    public class DataVisualizerRepository : IDataVisualizerRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<DataVisualizerRepository> _logger;

        public DataVisualizerRepository(DataContext context, ILogger<DataVisualizerRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task AddAsync(FileOutputData outputData)
        {

            try
            {
                await _context.FileOutputDatas.AddAsync(outputData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }           
        }

        public async Task DeleteAsync()
        {

            try
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM FileOutputDatas");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
