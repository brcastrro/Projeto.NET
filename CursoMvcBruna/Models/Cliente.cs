using System.ComponentModel.DataAnnotations;

namespace CursoMvcBruna.Models
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid(); //o guid precisa ser inicializado
            Enderecos = new List<Endereco>();
        }

        [Key]
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
