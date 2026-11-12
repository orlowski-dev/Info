using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Info.Models;

public sealed class Text
{
    public int TextId { get; set; }

    [Required(ErrorMessage = "Tytuł jest wymagany.")]
    [Display(Name = "Tytuł tekstu:")]
    [StringLength(75, ErrorMessage = "Tytuł tekstu nie może przekraczać 75 znaków.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Streszczenie jest wymagane.")]
    [Display(Name = "Streszczenie tekstu:")]
    [StringLength(255, ErrorMessage = "Streszczenie nie może przekraczać 255 znaków.")]
    [DataType(DataType.MultilineText)]
    public string Summary { get; set; } = string.Empty;

    [Display(Name = "Słowa kluczowe:")]
    [StringLength(255, ErrorMessage = "Słowa kluczowe nie mogą być dłuższe niż 255 znaków.")]
    public string Keywords { get; set; } = string.Empty;

    [Required(ErrorMessage = "Treść jest wymagana.")]
    [Display(Name = "Treść tekstu:")]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; } = string.Empty;

    [Display(Name = "Grafika do tekstu:")]
    [StringLength(128, ErrorMessage = "Nazwa pliku nie może przekraczać 128 znaków.")]
    public string? Graphic { get; set; }

    [Display(Name = "Czy wyświetlać?")]
    public bool Active { get; set; } = true;

    [Display(Name = "Data dodania:")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public DateTimeOffset AddedDate { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<Opinion> Opinions { get; set; } = [];

    // Kategoria tekstu – relacja wymagana
    [Display(Name = "Kategoria tekstu:")]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // Autor tekstu – relacja opcjonalna
    [Display(Name = "Autor tekstu:")]
    public string? UserId { get; set; }

    public AppUser? Author { get; set; }
}
