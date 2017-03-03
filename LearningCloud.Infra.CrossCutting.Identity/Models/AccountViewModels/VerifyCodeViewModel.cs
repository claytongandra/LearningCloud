
using System.ComponentModel.DataAnnotations;
namespace LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código.")]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Lembrar desse navegador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}
