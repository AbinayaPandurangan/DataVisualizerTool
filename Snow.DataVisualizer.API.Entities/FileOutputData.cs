using Snow.DataVisualizer.API.Shared.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.DataVisualizer.API.Entities
{
    public class FileOutputData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public char Hastag { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Value { get; set; }
        public string ColorHex { get { return Utils.GetColorCode(this.Color); } }
    }
}
