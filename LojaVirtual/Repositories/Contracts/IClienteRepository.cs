using LojaVirtual.Models;
using System.Collections.Generic;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, string Senha);

        //CRUD
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        Cliente ObterCliente(int Id);
        IEnumerable<Cliente> ObterTodosClientes();
    }
}
