using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

            int totalStocks = dataTable.Count;

            foreach (var tableRow in dataTable)
            {
                DateTime timeScraped = DateTime.Now;
                string stockSymbol = tableRow.SelectSingleNode("td/h3/a").InnerText;
                string lastPrice = tableRow.SelectSingleNode("td[4]").InnerText.Replace("&nbsp;", string.Empty);
                string InitChange = tableRow.SelectSingleNode("td[5]/span").InnerText.Replace("&nbsp;", "").Replace(" ", "").Replace("&#9650;", " ");  

                int changeLength = InitChange.Length;

                int cutString = 4;
                string change = InitChange.Substring(0, cutString).Trim();
                string changePercent = InitChange.Substring(cutString).Trim();



                /*string stringChange = "";
                if (changeNode == null)
                    stringChange = "no data found";
                else = ClarifyNode(changeNode);*/


                    stock = new HAPStock(timeScraped, stockSymbol, lastPrice, change, changePercent);

                stockData.Add(stock);
                InsertScrapeToDatabase(stock);

            }

            /*public static string ClarifyNode (HtmlNode nodeText)
            {
                string change = nodeText.InnerText;
                Match changeNodeSpecialCharacters = Regex.Match(change, @"(&nbsp;&#9650;");
            }
            
            
            Console.WriteLine("Total stocks: {0}", totalStocks);*/

            
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
