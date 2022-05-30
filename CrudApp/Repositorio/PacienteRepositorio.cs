using CrudApp.Models;
using CrudApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace CrudApp.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly AppContext _appContext;

        public PacienteRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public PacienteModel ListarPorId(int id)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public List<PacienteModel> BuscarTodos()
        {
            return _appContext.Pacientes.ToList();
        }

        public PacienteModel Adicionar(PacienteModel Paciente)
        {
            _appContext.Pacientes.Add(Paciente);
            _appContext.SaveChanges();
            return Paciente;
        }

        public PacienteModel Atualizar(PacienteModel Paciente)
        {
            PacienteModel pacienteDB = ListarPorId(Paciente.Id);

            if (pacienteDB == null) throw new System.Exception("Houve um erro na atualização do paciente");

            pacienteDB.Nome = Paciente.Nome;
            pacienteDB.Cpf = Paciente.Cpf;
            pacienteDB.DataNascimento = Paciente.DataNascimento;
            pacienteDB.Sexo = Paciente.Sexo;
            pacienteDB.Telefone = Paciente.Telefone;
            pacienteDB.Email = Paciente.Email;

            _appContext.Pacientes.Update(pacienteDB);
            _appContext.SaveChanges();

            return pacienteDB;
        }

        public bool Apagar(int id)
        {
            PacienteModel pacienteDB = ListarPorId(id);

            if (pacienteDB == null) throw new System.Exception("Houve um erro ao tentar excluir o contato!");

            _appContext.Pacientes.Remove(pacienteDB);
            _appContext.SaveChanges();

            return true;
        }
    }
}
