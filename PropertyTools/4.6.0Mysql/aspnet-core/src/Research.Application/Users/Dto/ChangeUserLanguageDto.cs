using System.ComponentModel.DataAnnotations;

namespace Research.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}