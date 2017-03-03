using System;
using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {

        [Required(ErrorMessage = "Preencha o campo Usuário.")]
        [StringLength(100, ErrorMessage = "O {0} deve conter pelo menos {2} caracteres.", MinimumLength = 6)]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [StringLength(100, ErrorMessage = "O {0} deve conter pelo menos {2} caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome.")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[Display(Name = "Data Nascimento")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime DataNascimento { get; set; }
    }
}
