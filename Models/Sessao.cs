using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmeAPI.Models;

/// <summary>
/// Class Modeling a Session in a Cinema 
/// </summary>
public class Sessao
{
    /// <summary>
    /// Property of Place with maxLength of 50
    /// </summary>
    [Required]
    [MaxLength(50, ErrorMessage = "Lugar da sessao deve ter no maximo  50 caracteres")]
    public string Lugar { get; set; } = string.Empty;

    /// <summary>
    /// Foreign Key of Filme of the session 
    /// </summary>
    [ForeignKey(nameof(Filme))]
    public int? FilmeId { get; set; }

    /// <summary>
    /// Acessing Filme by lazy loading
    /// </summary>
    public virtual Filme? Filme { get; set; }



    /// <summary>
    /// ForeignKey of CinemaId
    /// </summary>
    [ForeignKey(nameof(Cinema))]
    public int? CinemaId { get; set; }

    /// <summary>
    /// Acessing Cinema by lazy Loading
    /// </summary>
    public virtual Cinema? Cinema { get; set; }
}
