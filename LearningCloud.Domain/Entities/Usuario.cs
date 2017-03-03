using System;

namespace LearningCloud.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            usu_id = Guid.NewGuid().ToString();
        }

        public string usu_id { get; set; }
        public string usu_nome { get; set; }
        public string usu_sobreNome { get; set; }
        public DateTime? usu_dataNascimento { get; set; }
        public string usu_sexo { get; set; }
        public int usu_nivel { get; set; }
        public string usu_status { get; set; }
        public DateTime? usu_dataCadastro { get; set; }
        public string usu_fotoPerfil { get; set; }
    }
}
