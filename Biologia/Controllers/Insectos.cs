using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biologia.Controllers
{
    public class Insectos
    {
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Usuario")]
        public String usuario { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Reino")]
        public String reino { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Phyllum")]
        public String phyllum { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Clase")]
        public String clase { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Orden")]
        public String orden { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Familia")]
        public String familia { get; set; }
     
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Nombre Cientifico")]
        public String Taxa {get; set;}
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Morfoespecie {get; set;}
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Abundancia { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display (Name = "Numero de Frasco")]
        public int NumFrasco {get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Tipo de Vegetacion")]
        public String TipoVegetacion { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Metodo de Colecta")]
        public String MetodoColecta { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Sustrato { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public String Localidad { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Display(Name = "Fecha de colecta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        //[RegularExpression("[0-5](°)[0-5](')[0-5](\") [N]")]
        [Display(Name = "Coordenadas  (90° 19 20\" N 90° 19 10\" W) ") ]
        public String Longitud { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        //[RegularExpression("00°00'00\"")]
        [Display(Name = "Altitud (msnm)")]
        public int Altitud { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
[Display(Name = "Información adicional")]
        public String informacion { get; set; }



    }
}
