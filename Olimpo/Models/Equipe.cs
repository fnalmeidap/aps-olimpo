using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

[Table("Equipe")]
public partial class Equipe : EntidadeBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string University { get; set; }
    [Required]
    public List<Participante> Members { get; set; }
}