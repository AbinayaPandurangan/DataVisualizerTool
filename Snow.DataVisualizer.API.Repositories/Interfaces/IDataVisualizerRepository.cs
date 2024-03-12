using Snow.DataVisualizer.API.Entities;

namespace Snow.DataVisualizer.API.Repositories.Interface
{
    public interface IDataVisualizerRepository
    {
        Task AddAsync(FileOutputData outputData);
        Task DeleteAsync();
    }
}
