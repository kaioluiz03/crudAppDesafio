using CrudApp.Models;
using CrudApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public IActionResult Index()
        {
            List<PacienteModel> Pacientes = _pacienteRepositorio.BuscarTodos();

            return View(Pacientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Informacoes(int id)
        {
            PacienteModel paciente = _pacienteRepositorio.ListarPorId(id);
            return View(paciente);
        }

        public IActionResult Editar(int id)
        {
            PacienteModel paciente = _pacienteRepositorio.ListarPorId(id);
            return View(paciente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PacienteModel paciente = _pacienteRepositorio.ListarPorId(id);
            return View(paciente);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _pacienteRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemdeSucesso"] = "O Paciente foi apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemdeErro"] = "Não foi possível apagar o paciente!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemdeErro"] = $"Não foi possível apagar o paciente! {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(PacienteModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepositorio.Adicionar(paciente);
                    TempData["MensagemdeSucesso"] = "O Paciente foi cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(paciente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemdeErro"] = $"Não foi possível cadastrar o novo paciente! {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(PacienteModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepositorio.Atualizar(paciente);
                    TempData["MensagemdeSucesso"] = "O Paciente foi alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", paciente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemdeErro"] = $"Não foi possível alterar os dados do paciente! {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
