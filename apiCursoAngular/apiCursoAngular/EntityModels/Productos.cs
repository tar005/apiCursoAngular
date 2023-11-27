using apiCursoAngular.EntityModels.BaseEntityModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCursoAngular.EntityModels
{
    [Table("productos")]
    public class Productos :BaseDomainModel
    {
        [Column("nombre",TypeName = "NVARCHAR(255)")]

        public string? Nombre { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("precio",TypeName = "NVARCHAR(255)")]
        public string? Precio { get; set; }

        [Column("imagen",TypeName = "NVARCHAR(255)")]
        public string? Imagen { get; set; }

    }
}
