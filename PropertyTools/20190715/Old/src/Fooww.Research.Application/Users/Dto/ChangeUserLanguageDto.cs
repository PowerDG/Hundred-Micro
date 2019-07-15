using System.ComponentModel.DataAnnotations;

namespace Fooww.Research.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}