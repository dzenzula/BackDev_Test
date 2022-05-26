using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class ButtonKeyboardCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public int ClickAmount { get; set; } = 0;
    }
}
