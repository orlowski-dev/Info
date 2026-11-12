using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Info.Models;

public sealed partial class AppUser : IdentityUser
{
    [Display(Name = "Imię:")]
    [MaxLength(20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków.")]
    [RegularExpression(
        @"^\p{Lu}\p{Ll}+$",
        ErrorMessage = "Imię powinno zaczynać się wielką literą i zawierać tylko litery."
    )]
    public string? FirstName { get; set; }

    [Display(Name = "Nazwisko:")]
    [MaxLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków.")]
    [RegularExpression(
        @"^\p{Lu}\p{Ll}+(?:-\p{Lu}\p{Ll}*)?$",
        ErrorMessage = "Nazwisko powinno zaczynać się wielką literą i zawierać tylko litery; dopuszczalny jest łącznik."
    )]
    public string? LastName { get; set; }

    [NotMapped]
    [Display(Name = "Imię i nazwisko:")]
    public string FullName
    {
        get
        {
            if (string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName))
            {
                return "Nie podano";
            }
            return $"{FirstName} {LastName}".Trim();
        }
    }

    [Display(Name = "Informacja o użytkowniku:")]
    [MaxLength(800, ErrorMessage = "Opis nie może przekraczać 800 znaków.")]
    [DataType(DataType.MultilineText)]
    public string? Information { get; set; }

    [Display(Name = "Zdjęcie profilowe:")]
    [MaxLength(128)]
    [FileExtensions(
        Extensions = ".jpg,.png,.gif",
        ErrorMessage = "Dozwolone rozszerzenia plików to: .jpg, .png, .gif."
    )]
    public string? Photo { get; set; }

    // Teksty użytkownika
    public ICollection<Text> Texts { get; set; } = [];

    // Komentarze i oceny użytkownika
    public ICollection<Opinion> Opinions { get; set; } = [];
}
