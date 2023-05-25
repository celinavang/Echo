using System.ComponentModel.DataAnnotations;
using Echo.Services;

namespace Echo.Models
{
    public class Exhibit
    {
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Indtast venligt et gyldigt 4-cifre ID..")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Indtast venligt et gyldigt 4-cifre ID..")]
        [Required(ErrorMessage ="Indtast venligt et gyldigt 4-cifre ID..")]
        public string ID { get; set; }

        [StringLength(60, MinimumLength =5, ErrorMessage ="Indtast venligst et navn mellem 5-60 cifre..")]
        [Required(ErrorMessage = "Indtast venligts et ustillingsnavn..")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Indtast venligst en sti til videofilen..")]
        public string Videourl { get; set; }
        [Required(ErrorMessage = "Indtast venligst en sti til videofilen..")]
        public string Videourlen { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Indtast venligst et navn mellem 5-60 cifre..")]
        [Required(ErrorMessage = "Indtast venligts et ustillingsnavn..")]
        public string Nameen { get; set; }

        [Required]
        public int ArticledaID { get; set; }

        [Required]
        public int ArticleenID { get; set; }
    }
}
