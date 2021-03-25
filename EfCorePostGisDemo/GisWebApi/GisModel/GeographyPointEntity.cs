using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GisWebApi.GisModel
{
    public class GeographyPointEntity
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "geography (point)")]
        [Required]
        public NetTopologySuite.Geometries.Point Location { get; set; }
    }
}