using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Models
{
    public class ProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "")]
        [Display(Name = "Item Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "")]
        [Display(Name = "Cost")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "")]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Full Item Description")]
        public string FullDescription { get; set; }

    }
}