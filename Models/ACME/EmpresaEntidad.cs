using System.ComponentModel.DataAnnotations;

namespace Models.ACME
{
    public class EmpresaEntidad
    {
        [Range(0,int.MaxValue,ErrorMessage ="Debe seleccionar una empresa.")]
        [Display(Name = "Codigo")]

        public int? IDEmpresa { get; set; }

        [Required(ErrorMessage ="Debe seleccionar un ipo de empresa.")]
        [Range(1,int.MaxValue,ErrorMessage ="Debe seleccionar un tipo de empresa.")]
        [Display(Name ="Tipo de empresa")]

        public int IDTipoEmpresa { get; set; }

        [Required(ErrorMessage ="El nombre de la empresa en obligatorio.")]
        [Display(Name ="Empresa")]
        
        public string Empresa { get; set;} = string.Empty;

        [Required(ErrorMessage = "El dirección de la empresa en obligatorio.")]
        [Display(Name = "Dirección")]

        public string Direccion { get; set;}=string.Empty;

        [Required(ErrorMessage = "El RUC de la empresa en obligatorio.")]
        [Display(Name = "RUC")]

        public string RUC { get; set; }=string.Empty;

        [Required(ErrorMessage = "Debe ingresar la fecha de creación.")]
        [Display(Name = "Fecha creación")]

        public DateTime FechaCreacion { get; set;}=DateTime.Now;

        [Required(ErrorMessage = "Debe ingresar el presupuesto.")]
        [Display(Name = "Presupuesto")]

        public decimal Presupuesto { get; set;}

        public bool Activo { get; set; }= true;

        public TipoEmpresaEntidad? TipoEmpresa { get; set;}
    }
}
