using Microsoft.AspNetCore.Mvc;
using SiteMVC.Interface;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Controllers
{
    public class UsuariosController : Controller
    {
        protected readonly IUsuarioRepositorio _usuariosRepositorio;
        public UsuariosController(IUsuarioRepositorio repositorio)
        {
            _usuariosRepositorio = repositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> ListaDeUsuarios = _usuariosRepositorio.ListarUsuarios();
            return View(ListaDeUsuarios);
        }

        public IActionResult AdicionarTela()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)   // <-- O "ModelState.IsValide" verifica se os requisitos de validação que colocamos na model se cumprem. Caso sim retorna "True" e continua. Caso não ele retirna para a view da tela de cadastro.
                {
                    _usuariosRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";  // <-- Uma vez que o usuario foi cadastrado com sucesso criamos uma variavel temporaria(TempDate) e armazenamos a mensagem que iremos jogar no alerta.
                    return RedirectToAction("Index");
                }

                return View("AdicionarTela");

            }catch(Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o usuario, detatlhes do erro: "+ex.Message;  // <-- Se por algum motivo o cadastro não der certo, criamos outra variavel temporaria(TempDate) e armazenamos a mensagem de erro, e mais a mensagem de erro que esta armazenada na nossa "Exception ex".
                return RedirectToAction("Index");
            }
        }

        public IActionResult EditarTela(int id)
        {
            UsuarioModel usuario = _usuariosRepositorio.GetById(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariosRepositorio.Alterar(usuario);
                    TempData["MensagemSucesso"] = "Usuario editado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("EditarTela");

            }catch(Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao editar o usuario, detatlhes do erro: " + ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult RemoverTela(int id)
        {
            UsuarioModel usuario = _usuariosRepositorio.GetById(id);
            return View(usuario);
        }

       
        public IActionResult RemoverBanco(int id)
        {
            try
            {
                _usuariosRepositorio.Remover(id);
                TempData["MensagemSucesso"] = "Usuario excluido com sucesso";
                return RedirectToAction("Index");

            }catch(Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao excluir o usuario, detatlhes do erro: " + ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        
    }
}
