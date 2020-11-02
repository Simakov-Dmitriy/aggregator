using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class CreateCuponViewModel
    {
        [Required]
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public double SaleProcent { get; set; }

        [Required]
        public string CityCoise { get; set; }
        public List<SelectListItem> Cities { get; set; }

        [Required]
        public string PromoCode { get; set; }
        public DateTime ClosingDate { get; set; }

        public string SpecialPropositionId { get; set; }
        public List<SelectListItem> SpecialPropositions { get; set; }

    }
}
