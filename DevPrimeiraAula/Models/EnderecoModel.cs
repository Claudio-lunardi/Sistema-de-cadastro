using System.ComponentModel.DataAnnotations;

namespace DevPrimeiraAula.Models
{
    public class EnderecoModel
    {
        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O logradouro deve ter no minimo 20 a 50 caracteres")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo Número é obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "O número deve ter no minimo 1 a 20 caracteres")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "O Complemneto deve ter no minimo 50 caracteres")]
        public string? Complemento { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A cidade deve ter no minimo 5 caracteres")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O Estado deve ter no minimo 2 caracteres")]
        public string Estado { get; set; }
    }
}
