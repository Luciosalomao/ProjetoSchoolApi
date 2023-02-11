using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjectoSchool_API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        /* Configuração para ignorar referencias circulares */
        //[JsonIgnore]
        //[IgnoreDataMember]
        public List<Aluno> ? Alunos { get; set; }
    }
}
