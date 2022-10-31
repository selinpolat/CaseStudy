using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using Case.Model;

namespace Case.PageObject
{
    public class SearchPage
    {
        public WebDriver WebDriver { get; private set; }
        public Browser WebBrowser { get; set; }
        public SearchPage(WebDriver webDriver, Browser webBrowser)
        {
            WebDriver = webDriver;
            WebBrowser = webBrowser;
        }
        public void SearchGoogle(string keyword)
        {
            WebDriver.Navigate().GoToUrl($"{WebBrowser.SearchURL}?q={keyword}&num={13}");
        }

        public void SearchYandex(string keyword)
        {
            WebDriver.Navigate().GoToUrl($"{WebBrowser.SearchURL}?text={keyword}");
        }
        public List<SearchResult> GetFirstTenElementInGoogle()
        {
            List<SearchResult> resultListChrome = new List<SearchResult>();
            var webElements = WebDriver.FindElements(By.XPath(("//*[contains(@class,'TbwUpd NJjxre') or contains(@class,'VwiC3b yXK7lf MUxGbd yDYNvb lyLwlc') or contains(@class,'LC20lb MBeuO DKV0Md')]"))).Take(30).ToList();
            SearchResult searchResultItem = null;
            for (int i = 0; i < 30; i = i + 3)
            {
                searchResultItem = new SearchResult
                {
                    Title = webElements[i].Text,
                    URL = webElements[i + 1].Text,
                    Description = webElements[i + 2].Text
                };
                resultListChrome.Add(searchResultItem);
            }
            return resultListChrome;
        }
        public List<SearchResult> GetFirstTenElementInYandex()
        {
            List<SearchResult> resultListYandex = new List<SearchResult>();
            var webElements = WebDriver.FindElements(By.XPath(("//*[(@class='OrganicTitleContentSpan organic__title') or (@class='OrganicTextContentSpan') or (@class='Path Organic-Path path organic__path')]"))).Take(30).ToList();
       
            SearchResult searchResultItem = null;
            for (int i = 0; i < 30; i = i + 3)
            {
                searchResultItem = new SearchResult
                {
                    Title = webElements[i].Text,
                    URL = webElements[i + 1].Text,
                    Description = webElements[i + 2].Text
                };
                resultListYandex.Add(searchResultItem);
            }
            return resultListYandex;
        }
    }
}
