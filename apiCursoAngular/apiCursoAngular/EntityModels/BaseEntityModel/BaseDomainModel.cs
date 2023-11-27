using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCursoAngular.EntityModels.BaseEntityModel
{
    public class BaseDomainModel
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
    }
}
