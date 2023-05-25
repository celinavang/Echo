using System.ComponentModel.DataAnnotations;
namespace Echo.Models
{
    public class Article
    {
       
        [Required(ErrorMessage = "Indtast venligst et gyldigt ID..")] 
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Indtast venligst et navn mellem 5-60 cifre..")]
        [Required(ErrorMessage = "Indtast venligts et artikelnavn..")] 
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Indtast venligst en rubrik mellem 5-60 cifre..")]
        [Required(ErrorMessage = "Indtast venligts en rubrik..")]
        public string Header { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Indtast venligst en underrubrik mellem 5-60 cifre..")]
        [Required(ErrorMessage = "Indtast venligts en underrubrik..")] 
        public string Subheader { get; set; }
        [Required(ErrorMessage = "Indtast venligts en brødtekst..")] 
        public string Bodytext { get; set;}

    }
}
