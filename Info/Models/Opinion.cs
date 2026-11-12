using System.ComponentModel.DataAnnotations;

namespace Info.Models;

public enum Rating
{
    [Display(Name = "Nieprzydatny")]
    Useless = 1,

    [Display(Name = "Słaby")]
    Poor = 2,

    [Display(Name = "Przeciętny")]
    Average = 3,

    [Display(Name = "Dobry")]
    Good = 4,

    [Display(Name = "Świetny")]
    Excellent = 5,
}

public sealed class Opinion
{
    public int OpinionId { get; set; }

    [Required(ErrorMessage = "Proszę podać treść komentarza.")]
    [Display(Name = "Treść komentarza:")]
    [DataType(DataType.MultilineText)]
    [MinLength(3, ErrorMessage = "Komentarz musi mieć co najmniej 3 znaki.")]
    [MaxLength(1000, ErrorMessage = "Komentarz nie może przekraczać 1000 znaków.")]
    public string Comment { get; set; } = string.Empty;

    [Display(Name = "Data dodania:")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTimeOffset AddedDate { get; set; } = DateTimeOffset.UtcNow;

    [Display(Name = "Ocena tekstu:")]
    [Range(1, 5, ErrorMessage = "Proszę wybrać ocenę od 1 do 5.")]
    public Rating? Rating { get; set; }

    // Komentowany tekst – relacja wymagana
    [Display(Name = "Komentowany tekst:")]
    public int TextId { get; set; }
    public Text Text { get; set; } = null!;

    // Autor komentarza – relacja opcjonalna
    [Display(Name = "Autor komentarza:")]
    public string? UserId { get; set; }
    public AppUser? Author { get; set; }
}
