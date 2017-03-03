using System;
using System.Collections.Generic;

namespace LearningCloud.Domain.Entities
{
    public class AssinaturaNivel
    {
        public int asn_id { get; set; }
        public string asn_titulo { get; set; }
        public string asn_descricao { get; set; }
        public int asn_nivel { get; set; }
        public string asn_status { get; set; }

     //   public virtual IEnumerable<Aula> asn_aulas { get; set; }
    }
}
