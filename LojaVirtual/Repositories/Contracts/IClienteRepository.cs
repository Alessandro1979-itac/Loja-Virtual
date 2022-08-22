using LojaVirtual.Models;
using X.PagedList;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, string Senha);

        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        Cliente ObterCliente(int Id);
        IPagedList<Cliente> ObterTodosClientes(int? pagina, string pesquisa);
    }
}
