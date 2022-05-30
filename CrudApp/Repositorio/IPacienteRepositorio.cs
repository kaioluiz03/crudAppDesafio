using CrudApp.Models;
using System.Collections.Generic;

namespace CrudApp.Repositorio
{
    public interface IPacienteRepositorio
    {
        PacienteModel ListarPorId(int id);
        List<PacienteModel> BuscarTodos();
        PacienteModel Adicionar(PacienteModel Paciente);
        PacienteModel Atualizar(PacienteModel Paciente);
        bool Apagar(int id);
    }
}
