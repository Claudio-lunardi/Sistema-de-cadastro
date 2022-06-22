using System.ComponentModel.DataAnnotations;

namespace DevPrimeiraAula.Models
{
    public class ClienteModel : EnderecoModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 caracteres.")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O RG é obrigatório.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 caracteres.")]
        public string RG { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 a 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Este campo deve ter no mínimo 15 caracteres.")]
        public string? Telefone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular é obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Este campo deve ter no mínimo 15 caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O ativo completo é obrigatório.")]
        public bool Ativo { get; set; }
    }
}
