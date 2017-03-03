using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Celular.")]
        [Phone]
        [Display(Name = "Celular")]
        public string Number { get; set; }
    }
}
