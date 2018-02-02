using System.ComponentModel.DataAnnotations;

namespace AKQA.CodingChallenge.Web.Models
{
    public class Customer
    {
        public Customer()
        {
            WordAmount = string.Empty;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter person name.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public string WordAmount { get; set; }
    }
}