using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookApplication.Models
{
    public class ListModel : IValidatableObject
    {
        public List<Book> Result { get; set; }
        [System.ComponentModel.DisplayName("Название")]
        public string Name { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}