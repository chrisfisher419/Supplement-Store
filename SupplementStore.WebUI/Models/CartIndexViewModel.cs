using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupplementStore.Domain.Entities;

namespace SupplementStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}