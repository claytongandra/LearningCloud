using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class VerifyPhoneNumberViewModel
    {
       [Required(ErrorMessage = "Preencha o campo Código.")]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número de celular.")]
        [Phone]
        [Display(Name = "Número de celular")]
        public string PhoneNumber { get; set; }
    }
}
