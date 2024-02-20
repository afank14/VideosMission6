using System.ComponentModel.DataAnnotations;

namespace VideosMission6.Models
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        public string MajorName { get; set; }

    }
}
