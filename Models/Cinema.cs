

using FilmeAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmeAPI;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo do nome e obrigatorio")]
    public string Nome { get; set; } = string.Empty;
    
    [ForeignKey(nameof(Endereco))]
    public int EnderecoId { get; set; }

    public virtual Endereco? Endereco { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; } = new HashSet<Sessao>();
}
