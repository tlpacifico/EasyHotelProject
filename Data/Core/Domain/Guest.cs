using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Core.Domain;

namespace Data.Core.Domain
{
    [Table("Guests")]
    public class Guest : BaseModel
    {
       
        public string Nome { get; set; } // nome (length: 120)
        public string Cpf { get; set; } // cpf (length: 11)
        public string Uf { get; set; } // uf (length: 2)
        public string Cidade { get; set; } // cidade (length: 20)
        public string Prefixo { get; set; } // prefixo (length: 6)
        public string Logradouro { get; set; } // logradouro (length: 40)
        public string Bairro { get; set; } // bairro (length: 20)
        public int Numero { get; set; } // numero
        public string Cep { get; set; } // cep (length: 8)
        public string Fone { get; set; } // fone (length: 12)
        public string Email { get; set; } // email (length: 30)
        public string DsComplemento { get; set; } // dsComplemento (length: 300)
        public DateTime? DtNascimento { get; set; } // dtNascimento
    }
}