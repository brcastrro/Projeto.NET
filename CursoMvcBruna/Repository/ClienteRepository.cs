using CursoMvcBruna.Context;
using CursoMvcBruna.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CursoMvcBruna.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CursoMvcContext _context;

        public ClienteRepository(CursoMvcContext context)
        {
            _context = context;
        }

        public Cliente ObterPorCPF(string cpf)
        {
            return _context.Clientes.FirstOrDefault(c => c.CPF == cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(Guid Id)
        {
            return _context.Clientes.FirstOrDefault(c => c.ClienteId == Id);
        }

        public List<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
           _context.Update(cliente);
           _context.SaveChanges();
           
            
        }

        public void Remover(Guid id)

        {
            _context.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        
    }
}
