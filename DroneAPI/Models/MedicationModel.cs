using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DroneAPI.Models
{
    public class MedicationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //allowe only letters, numbers, ‘-‘, ‘_’

        [RegularExpression(@"^[a-zA-Z0-9-_]+$")]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("WeightLimit", TypeName = "decimal")]
        public decimal Weight { get; set; }


        //allowe only upper case letters, underscore and numbers.
        [RegularExpression(@"^[A-Z0-9_]+$")]
        public string Code { get; set; }

        public byte[]? Image { get; set; }
    }
}
