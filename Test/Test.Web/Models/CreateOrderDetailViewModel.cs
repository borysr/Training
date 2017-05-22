using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Web.Models
{
    public class CreateOrderDetailViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [HiddenInput]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Decimal ItemPrice { get; set; }

    }
}