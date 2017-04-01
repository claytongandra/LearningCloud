using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LearningCloud.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningCloud.MVC.Areas.Admin.ViewModels
{
    public class AulaViewModel : IValidatableObject
    {
        [Key]
        public int Aula_Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título.")]
        [StringLength(200, ErrorMessage = "O {0} deve possuir no mínimo {2} e máximo {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Título")]
        public string Aula_Titulo { get; set; }

        [DisplayName("Tipo Conteúdo")]
        [Required(ErrorMessage = "Informe o tipo do conteúdo.")]
        public string aul_tipoconteudo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Introdução.")]
        [StringLength(8000, ErrorMessage = "O {0} deve possuir no mínimo {2} e máximo {1} caracteres.", MinimumLength = 2)]
        [AllowHtml]
        [DisplayName("Introdução")]
        public string aul_indroducao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição.")]
        [StringLength(8000, ErrorMessage = "O {0} deve possuir no mínimo {2} e máximo {1} caracteres.", MinimumLength = 2)]
        [AllowHtml]
        [DisplayName("Descrição")]
        public string aul_descricao { get; set; }

        [AllowHtml]
        [DisplayName("Pré-requisitos")]
        public string aul_prerequisitos { get; set; }
        
        //[DisplayName("Imagem")]
        //public string aul_imagem { get; set; }

        [DisplayName("Tempo do Vídeo")]
        public string aul_tempovideo { get; set; }

        [DisplayName("Vídeo")]
        public string aul_video { get; set; }

        [AllowHtml]
       // [Column(TypeName = "varchar(MAX)"), MaxLength]
        [DisplayName("Conteúdo Artigo")]
        public string aul_conteudoartigo { get; set; }

        [DisplayName("Palavras Chave")]
        public string aul_palavraschave { get; set; }

        [DisplayName("Status")]
        [Column(TypeName = "char")]
        [Required(ErrorMessage = "Informe o status da aula.")]
        public string aul_status { get; set; }

        [Required(ErrorMessage = "Selecione o nível de disponibilidade.")]
        [DisplayName("Disponível a partir")]
        public int aul_fk_assinaturanivel { get; set; }

        public virtual AssinaturaNivel aul_assinaturanivel { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Aula_DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Aula_DataAlteracao { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (aul_tipoconteudo == "V" && (string.IsNullOrEmpty(aul_video) || string.IsNullOrEmpty(aul_tempovideo)))
            {
                yield return new ValidationResult("Preenha os campos obrigatórios na aba Videoaula.");

                if (aul_tipoconteudo == "V" && string.IsNullOrEmpty(aul_video))
                    yield return new ValidationResult("Adicione o vídeo.", new string[] { "aul_video" });

                if (aul_tipoconteudo == "V" && string.IsNullOrEmpty(aul_tempovideo))
                {
                    yield return new ValidationResult("Informe o tempo do vídeo.", new string[] { "aul_tempovideo" });
                }
            }

            if (string.IsNullOrEmpty(aul_indroducao))
            {
                yield return new ValidationResult("Preenha o campo obrigatório na aba Introdução.");
            }

            if (string.IsNullOrEmpty(aul_descricao))
            {
                yield return new ValidationResult("Preenha o campo obrigatório na aba Descrição.");
            }

            if (aul_tipoconteudo == "A" && string.IsNullOrEmpty(aul_conteudoartigo)) { 
                yield return new ValidationResult("Preenha os campos obrigatórios na aba Artigo.");
                yield return new ValidationResult("Informe o conteúdo do artigo.", new string[] { "aul_conteudoartigo" });
            }
        }

    }
}