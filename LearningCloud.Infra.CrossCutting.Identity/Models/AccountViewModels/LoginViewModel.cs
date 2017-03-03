using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
       [Required(ErrorMessage = "Preencha o campo Usuário ou Email.")]
        [Display(Name = "Usuário ou Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Mantenha-me conectado.")]
        public bool RememberMe { get; set; }
    }
}