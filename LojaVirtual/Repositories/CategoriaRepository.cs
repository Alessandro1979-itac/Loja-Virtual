using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        const int _pageSize = 10;
        LojaVirtualContext _banco;
        public CategoriaRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Categoria categoria = ObterCategoria(Id);
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            int listPaged = pagina ?? 1;

            return _banco.Categorias.Include(a => a.CategoriaPai).ToPagedList<Categoria>(listPaged, _pageSize);
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias;
        }
    }
}
