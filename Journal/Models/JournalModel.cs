using System.ComponentModel.DataAnnotations;

namespace Journal.Models {
   public class JournalModel {
      [Display(Name = "Namn:")]
      [Required(ErrorMessage = "Namn måste vara ifyllt!")]
      public string? Name { get; set; }
      [Display(Name = "Träning:")]
      [Required (ErrorMessage = "Innehåll måste vara ifyllt!")]
      public string? Content { get; set; }
      [Display(Name = "Datum:")]
      [Required (ErrorMessage = "Datum måste vara ifyllt!")]
      public string? Date { get; set; }
   }
}