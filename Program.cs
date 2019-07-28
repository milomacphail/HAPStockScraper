using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHAPScraper
{
    class Scrape : DatabaseControl
    {
        static void Main(string[] args)
        {

            string nasdaqUrl = "https://www.nasdaq.com/markets/unusual-volume.aspx";


            HtmlWeb webNav = new HtmlWeb();
            HtmlDocument document = webNav.Load(nasdaqUrl);

            HtmlNodeCollection dataTable = document.DocumentNode.SelectNodes("//*[@id='_up']/table/tr");


            HAPStock stock;
            List<HAPStock> stockData = new List<HAPStock>();


            foreach (var tableRow in dataTable)
            {
                DateTime timeScraped = DateTime.Now;
                string stockSymbol = tableRow.SelectSingleNode("td/h3/a").InnerText;
                string lastPrice = tableRow.SelectSingleNode("td[4]").InnerText.Replace(" ", string.Empty);
                string change = tableRow.SelectSingleNode("td[5]/span").InnerText;
                string percentChange = tableRow.SelectSingleNode("td[7]").InnerText;


                stock = new HAPStock(timeScraped, stockSymbol, lastPrice, change, percentChange);

                stockData.Add(stock);
                InsertScrapeToDatabase(stock);

            }
            
            int totalStocks = dataTable.Count;
            Console.WriteLine("Total stocks: {0}", totalStocks);

            
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
