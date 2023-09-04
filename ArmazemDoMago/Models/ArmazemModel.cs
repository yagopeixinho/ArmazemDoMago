using System.ComponentModel.DataAnnotations;

namespace ArmazemDoMago.Models
{
    public class ArmazemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Poder Mágico é obrigatório.")]
        public int PoderMagico { get; set; }
    }
}
