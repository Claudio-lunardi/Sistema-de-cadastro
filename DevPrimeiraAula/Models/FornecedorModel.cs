

using System.ComponentModel.DataAnnotations;

namespace DevPrimeiraAula.Models
{
    public class FornecedorModel : EnderecoModel
    {
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "CNPJ Deve ter no minimo 18 caracteres ")]
        public string CNPJ { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "  O Nome é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome deve ter no minimo 5 a 100 caracteres ")]
        public string Nome { get; set; }


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "0 Telefone é obrigatório")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Telefone deve ter no minimo 15 caracteres ")]
        public string Telefone { get; set; }


        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "0 Ativo é obrigatório")]
        public bool Ativo { get; set; }

    }
}
