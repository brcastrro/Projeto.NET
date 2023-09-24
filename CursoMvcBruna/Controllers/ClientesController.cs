using Microsoft.AspNetCore.Mvc;
using CursoMvcBruna.ViewModels;
using CursoMvcBruna.Repository;
using CursoMvcBruna.Models;
using CursoMvcBruna.CrossCuttingMvcFilters;

namespace CursoMvcBruna.Controllers
{
    [GlobalErrorHandler]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {

            _clienteRepository = clienteRepository;
        }


        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var Clientes = _clienteRepository.ObterTodos();
            return View(Clientes);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cliente = _clienteRepository.ObterPorId(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return View(Cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                {
                    Nome = clienteEnderecoViewModel.Nome,
                    Email = clienteEnderecoViewModel.Email,
                    CPF = clienteEnderecoViewModel.CPF,
                    DataNascimento = clienteEnderecoViewModel.DataNascimento,
                    DataCadastro = DateTime.Now,
                    Ativo = true
                };

                Endereco endereco = new Endereco()
                {
                    Logradouro = clienteEnderecoViewModel.Logradouro,
                    Numero = clienteEnderecoViewModel.Numero,
                    Complemento = clienteEnderecoViewModel.Complemento,
                    Bairro = clienteEnderecoViewModel.Bairro,
                    CEP = clienteEnderecoViewModel.CEP,
                    Cidade = clienteEnderecoViewModel.Cidade,
                    Estado = clienteEnderecoViewModel.Estado
                };

                cliente.Enderecos.Add(endereco);

                _clienteRepository.Adicionar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                DataCadastro = DateTime.Now,
                Ativo = true
            };

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ClienteViewModel clienteViewModel)
        {
           
            var cliente = _clienteRepository.ObterPorCPF(clienteViewModel.CPF);


            if (cliente == null)
            {
                return NotFound();
            }
                
                        
            cliente.Nome = clienteViewModel.Nome;
            cliente.Email = clienteViewModel.Email;
            cliente.CPF = clienteViewModel.CPF;
            cliente.DataNascimento = clienteViewModel.DataNascimento;
                
            

            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_clienteRepository == null)
            {
                return Problem("Entity set 'CursoMvcContext.ClienteViewModel'  is null.");
            }
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente != null)
            {
                _clienteRepository.Remover(id);
            }


            return RedirectToAction(nameof(Index));
        }
  }
}
