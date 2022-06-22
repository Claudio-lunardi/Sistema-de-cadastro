using System.ComponentModel.DataAnnotations;

namespace DevPrimeiraAula.Models
{
    public class FuncionarioModel : EnderecoModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CPF deve ter no mínimo 14 caracteres")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O RG é obrigatório")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "RG dete ter no mínimo 5 a 30 caracteres")]
        public string RG { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome deve ter no mínino 5 a 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Este campo deve ter no mínino 15 caracteres")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Celular é obrigatório")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Este campo deve ter no mínino 15 caracteres")]
        public string Celular { get; set; }

        [Display(Name = "Data de inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O campo ativo é obrigatório")]
        public bool Ativo { get; set; }
    }
}
