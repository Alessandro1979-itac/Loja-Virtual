﻿using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        const int _pageSize = 10;
        private LojaVirtualContext _banco;
        public ColaboradorRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(a => a.Senha).IsModified = false;
            _banco.SaveChanges();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(a => a.Nome).IsModified = false;
            _banco.Entry(colaborador).Property(a => a.Email).IsModified = false;
            _banco.Entry(colaborador).Property(a => a.Tipo).IsModified = false;

            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Colaborador cliente = ObterColaborador(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            int listPaged = pagina ?? 1;

            return _banco.Colaboradores.Where(a => a.Tipo != "G").ToPagedList<Colaborador>(listPaged, _pageSize);
        }

        public List<Colaborador> ObterColaboradorPorEmail(string email)
        {
            return _banco.Colaboradores.Where(a => a.Email == email).AsNoTracking().ToList();
        }
    }
}
