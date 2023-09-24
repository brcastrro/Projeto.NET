using System.ComponentModel.DataAnnotations;

namespace CursoMvcBruna.Models
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}

