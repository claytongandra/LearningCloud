using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class SendCodeViewModel
    {

        [Required(ErrorMessage = "Informe Provedor o de dois fatores de Autenticação")]
        [Display(Name = "Provedor de dois fatores de Autenticação")]
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
