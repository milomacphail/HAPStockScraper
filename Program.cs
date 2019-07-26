using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHAPScraper
{
    class Scrape
    {
        static void Main(string[] args)
        {

            string nasdaqUrl = "https://www.nasdaq.com/markets/unusual-volume.aspx";


            HtmlWeb webNav = new HtmlWeb();
            HtmlDocument document = webNav.Load(nasdaqUrl);

            var TableHeader = document.DocumentNode.SelectNodes("//*[@id='_up']/table/tr").ToList();

            foreach (var row in TableHeader)
            {
                Console.WriteLine(row.InnerText);
                
            }
            Console.ReadKey();

        }
    }
}
        

        /*public string Url { get => nasdaqUrl; set => nasdaqUrl = value; }

        
    }
  }
  */

        /*public void ScrapeData()
        {
            Stock stock;
            List<stock> StockData = new List<Stock>();

            HtmlNodeCollection tableNodes = document.DocumentNode.SelectNodes("//*[@id='_active']/table/tr");

        if (tableNodes != null)
        {

        }

    }


    }



/*public static void WebScrape()
{

}*/
