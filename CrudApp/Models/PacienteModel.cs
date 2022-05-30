using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome do paciente precisa ser digitado!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cpf do paciente precisa ser digitado!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data de nascimento do paciente precisa ser digitado!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Gênero sexual do paciente precisa ser digitado!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Telefone do paciente precisa ser digitado!")]
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage ="O telefone informado não é válido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email do paciente precisa ser digitado!")]
        [EmailAddress(ErrorMessage ="O Email informado não é válido!")]
        public string Email { get; set; }
    }
}
