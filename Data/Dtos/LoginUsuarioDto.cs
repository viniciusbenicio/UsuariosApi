using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string userName { get; set; }
        [Required]

        public string password { get; set; }
    }
}
