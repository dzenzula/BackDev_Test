using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class ButtonKeyboardUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public int ClickAmount { get; set; }
    }
}
