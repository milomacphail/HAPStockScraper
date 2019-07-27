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

            var dataTable = document.DocumentNode.SelectNodes("//*[@id='_up']/table/tr").ToList();

            foreach (var tableRow in dataTable)
            {
                Console.WriteLine(tableRow.InnerText);

                string stockSymbol = tableRow.SelectSingleNode("//*[@id='_up']/table/thead/tr/th[1]").InnerText;
                string lastPrice = tableRow.SelectSingleNode("//*[@id='_up']/table/thead/tr/th[3]").InnerText;
                string change = tableRow.SelectSingleNode("//*[@id='_up']/table/thead/tr/th[4]").InnerText;
                string percentChange = tableRow.SelectSingleNode("//*[@id='_up']/table/thead/tr/th[6]").InnerText;

                Console.WriteLine(DateTime.Now);
                Console.WriteLine(stockSymbol);
                Console.WriteLine(lastPrice);
                Console.WriteLine(change);
                Console.WriteLine(percentChange);
            }
            
            int totalStocks = dataTable.Count;
            Console.WriteLine("Total stocks: {0}", totalStocks);

            List<DateTime> timeScraped = new List<DateTime>();
            List<string> stockSymbols = new List<string>();
            List<string> lastPrices = new List<string>();
            List<string> changes = new List<string>();
            List<string> percentChanges = new List<string>();



            for (int index =  0; index < totalStocks; index++)
            {




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
