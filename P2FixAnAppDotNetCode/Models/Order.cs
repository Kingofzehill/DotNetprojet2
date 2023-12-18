using System;
using System.Collections.Generic;
// SMO permet de géer les annotations de données,
// voir instruction [Required(ErrorMessage = "ErrorMissingName")]
// pour les champs du formulaire de Index.cshtml à contrôler
using System.ComponentModel.DataAnnotations;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using P2FixAnAppDotNetCode.Controllers;

namespace P2FixAnAppDotNetCode.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]

        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "ErrorMissingName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ErrorMissingAddress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "ErrorMissingCity")]
        public string City { get; set; }

        // SMO Bug B06 : upd zip code as mandatory
        [Required(ErrorMessage = "ErrorMissingZip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "ErrorMissingCountry")]
        public string Country { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}
