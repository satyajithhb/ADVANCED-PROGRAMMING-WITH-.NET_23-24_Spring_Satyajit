using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroAPI.DTOs
{
    public class ProductsDTO
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
    }
}