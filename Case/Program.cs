using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Case.PageObject;
using Case.Model;
using System.IO;

namespace Case
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string logFileName = String.Format("log_{0}.txt", DateTime.Now.ToString("yyyyMMddhhmmss"));
                using (StreamWriter writer = new StreamWriter(logFileName))
                {
                    Console.SetOut(writer);
                    Run();
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        public static List<SearchResult> CompareResults(List<SearchResult> source, List<SearchResult> compare)
        {
            List<SearchResult> results = new List<SearchResult>();
            foreach (var result in source)
            {
                foreach (var c in compare)
                {
                    if (c.Title == result.Title)
                    {
                        results.Add(result);
                    }
                }
            }
            return results;
        }
        public static void Run()
        {
            string keyword = "araba";
            //Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:\\Program Files\\chromedriver.exe");
            Log(($"{keyword} keyword is set to the variable"));
           

            WebDriver webDriver = new ChromeDriver();
            Log("Opened the Chrome Driver");

            webDriver.Manage().Cookies.DeleteAllCookies();
            Log("Chrome Driver is cleaned the cookies");

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.Manage().Window.Maximize();
            Log("Opened the Chrome Driver and cleaned the cookies");

            Browser browserGoogle = new Browser(SearchEngine.Chrome);
            SearchPage searchPageGoogle = new SearchPage(webDriver, browserGoogle);
            Log("Browser is created for Google search based on the keyword given");

            searchPageGoogle.SearchGoogle(keyword);
            var googleResults = searchPageGoogle.GetFirstTenElementInGoogle();
            Log("First 10 result from Google is kept in a structurued data");

            Browser browserYandex = new Browser(SearchEngine.Yandex);
            SearchPage searchPageYandex = new SearchPage(webDriver, browserYandex);
            Log("Browser is created for Yandex search based on the keyword given");

            searchPageYandex.SearchYandex(keyword);
            var yandexResults = searchPageYandex.GetFirstTenElementInYandex();
            Log("First 10 result from Yandex is kept in a structurued data ");

            Log("Comparing search results...");
            var sameResults = CompareResults(googleResults, yandexResults);
            Log("Compared the search results");
            foreach (var result in sameResults)
            {
                Log($"{result.Title}| {result.URL}| {result.Description}");
            }
            Log("Finishing the process");
            webDriver.Quit();
        }
        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} {message}");
        }
    }

}
