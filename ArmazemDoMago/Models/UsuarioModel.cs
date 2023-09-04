using System.ComponentModel.DataAnnotations;

namespace ArmazemDoMago.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string? Senha { get; set; }
    }
}
