using System;

namespace LearningCloud.Domain.Entities
{
    public class Aula
    {
        public int Aula_Id { get; set; }
        public string Aula_Titulo { get; set; }
        public string aul_tipoconteudo { get; set; }
        public string aul_indroducao { get; set; }
        public string aul_descricao { get; set; }
        public string aul_prerequisitos { get; set; }
       // public string aul_imagem { get; set; }
        public string aul_tempovideo { get; set; }
        public string aul_video { get; set; }
        public string aul_conteudoartigo { get; set; }
        public string aul_palavraschave { get; set; }
        public string aul_status { get; set; }
        public int aul_fk_assinaturanivel { get; set; }
        public virtual AssinaturaNivel aul_assinaturanivel { get; set; }

        //public virtual int aul_fk_instrutor { get; set; }
        //public virtual int aul_fk_operadorcadastro { get; set; }
        public DateTime Aula_DataCadastro { get; set; }
        //public virtual int aul_fk_operadoralteracao { get; set; }
        public DateTime? Aula_DataAlteracao { get; set; }
        //public virtual ICollection<Curso> Cursos { get; set; }
    }
}
