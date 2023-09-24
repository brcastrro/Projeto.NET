using CursoMvcBruna.Models;

namespace CursoMvcBruna.Repository
{
    public interface IClienteRepository

    {
        Cliente ObterPorCPF(string cpf);
        Cliente ObterPorEmail(string email);

        List<Cliente> ObterTodos();

        Cliente ObterPorId(Guid Id);

        void Adicionar(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Remover(Guid id);
       
    }
}
