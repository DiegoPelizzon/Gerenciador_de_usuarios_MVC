using SiteMVC.Banco;
using SiteMVC.Interface;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Repositorio
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        protected readonly BancoContext _banco;

        public UsuarioRepositorio(BancoContext bancocontext)
        {
            _banco = bancocontext;
        }

        public List<UsuarioModel> ListarUsuarios()
        {
            return _banco.usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            if(ContatoExistente(usuario)== true)
            {
                throw new Exception("Numero de contato ja cadastrado");
            }

            _banco.usuarios.Add(usuario);
            _banco.SaveChanges();

            return usuario;
        }

        public UsuarioModel GetById(int id)
        {
            return _banco.usuarios.FirstOrDefault(x=>x.id == id);
        }

        public UsuarioModel Alterar(UsuarioModel usuario)
        {
            UsuarioModel UsuarioParaEditar = GetById(usuario.id);

            if (UsuarioParaEditar == null)
            {
                throw new Exception("Houve um erro na atualização dos dados");
            }

            UsuarioParaEditar.nome = usuario.nome;
            UsuarioParaEditar.contato = usuario.contato;
            UsuarioParaEditar.email = usuario.email;

            _banco.usuarios.Update(UsuarioParaEditar);
            _banco.SaveChanges();

            return UsuarioParaEditar;
        }

        public void Remover(int id)
        {
            UsuarioModel UsuarioParaRemover = GetById(id);

            if (UsuarioParaRemover == null)
            {
                throw new Exception("Houve um erro ao remover o usuario");
            }
            _banco.usuarios.Remove(UsuarioParaRemover);
            _banco.SaveChanges();

           
        }

        public bool ContatoExistente(UsuarioModel usuario)
        {
            return _banco.usuarios.Any(x => x.contato == usuario.contato);

        }
    }

}
