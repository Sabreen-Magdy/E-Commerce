﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Order
{
    public record OrderDtoNew
    {
        //  وهو جاي من ال customer مش هيبقا ليه id 
        public int CustomerId { get; set; }
        //public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        //public DateTime? ConfirmDate { get; set; }
        //public int State { get; set; } = 0;
        public double OrderTotalCost { get; set; }
        public string CustomerAddress { get; set; }
        public List<ProductsToOrderDtoNew> productsperOrder { get; set; }
    }
    public record ProductsToOrderDtoNew
    {
        public int ProductVarientId { get; set; }
        public int Quantity { get; set; }
       // public ProductVariantDto? products { get; set; }
        public double TotalCostPerQuantity { get; set; }
    }
 }
