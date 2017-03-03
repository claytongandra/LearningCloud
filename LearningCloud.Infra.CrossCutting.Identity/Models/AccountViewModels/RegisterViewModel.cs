using System;
using System.ComponentModel.DataAnnotations;


namespace LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
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

        
        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        //[Required]
        //[StringLength(10, ErrorMessage = "Selecione o genero.")]
        //[Display(Name = " Sexo")]
        //public string Genero { get; set; }  

        //   public List<Genero> Generos { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha.")]
        [StringLength(100, ErrorMessage = "A {0} deve conter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Preencha o campo Confirmação da Senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha estão diferentes.")]
        public string ConfirmPassword { get; set; }
    }
}
