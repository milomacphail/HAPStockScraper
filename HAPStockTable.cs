//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleHAPScraper
{
    using System;
    using System.Collections.Generic;
    
    public partial class HAPStockTable
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Time_Scraped { get; set; }
        public string Stock_Symbol { get; set; }
        public string Last_Price { get; set; }
        public string Change { get; set; }
        public string Percent_Change { get; set; }
    }
}
