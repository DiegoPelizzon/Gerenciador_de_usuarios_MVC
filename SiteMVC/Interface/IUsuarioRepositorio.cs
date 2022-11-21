using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Interface
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);

        List<UsuarioModel> ListarUsuarios();

        UsuarioModel GetById(int id);

        UsuarioModel Alterar(UsuarioModel usuario);

        void Remover(int id);
    }
}
