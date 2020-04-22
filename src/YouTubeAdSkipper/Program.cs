using ColorConsole;
using DotSpinners;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace ChromeYouTubeAdSkipper
{
    internal class Program
    {
        private static readonly string _url = "https://youtube.com";
        private static readonly ConsoleWriter Output = new ConsoleWriter();
        private static IWebDriver driver;

        private static void Main(string[] args)
        {
            try
            {
                new DotSpinner(SpinnerTypes.Eyes, DoWork()).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message ?? "");
            }
        }

        private static async Task DoWork()
        {
            await Task.Run(() => DoMoreWork());
        }

        private static void DoMoreWork()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url);
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(35.0));
            while (true)
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath("//*[text()='Skip Ads' or text()='Skip Ad']"));
                    webDriverWait.Until(driver => element);
                    element.Click();
                    Output.WriteLine<string>("Skipping YouTube Ad...", ConsoleColor.Green);
                }
                catch (Exception)
                {}
            }
        }
    }
}
