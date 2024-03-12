using Snow.DataVisualizer.API.Entities;

namespace Snow.DataVisualizer.API.Repositories.DataContexts
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.FileOutputDatas.Any()) return;

            var sampleDatas = new List<FileOutputData>
            {
                new FileOutputData
                {
                    Hastag = '#',
                    Name = "A",
                    Color = "RED",
                    Value = 10
                }
            };
            foreach (var data in sampleDatas)
            {
                context.FileOutputDatas.Add(data);
            }

            context.SaveChanges();
        }
    }
}
