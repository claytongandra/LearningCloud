using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nova senha.")]
        [StringLength(100, ErrorMessage = "A {0} deve conter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da Senha")]
        [Compare("NewPassword", ErrorMessage = "A senha e a confirmação da senha estão diferentes.")]
        public string ConfirmPassword { get; set; }
    }
}
