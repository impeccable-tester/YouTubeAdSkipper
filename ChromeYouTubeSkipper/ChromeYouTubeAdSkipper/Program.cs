using System;
using System.Threading.Tasks;
using ColorConsole;
using DotSpinners;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ChromeYouTubeAdSkipper
{
    class Program
    {
        private static IWebDriver driver;
        static readonly string _url = "https://youtube.com";
        static readonly ConsoleWriter Output = new ConsoleWriter();

        static void Main(string[] args)
        {
            try
            {
                new DotSpinner(SpinnerTypes.Eyes, DoWork()).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }

        private static async Task DoWork() => await Task.Run(() => DoMoreWork());

        private static void DoMoreWork()
        {
            driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl(_url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));

            while (true)
            {
                try
                {
                    var element = driver.FindElement(By.XPath("//*[text()='Skip Ads' or text()='Skip Ad']"));
                    wait.Until(driver => element);
                    element.Click();
                    Output.WriteLine("Skipping YouTube Ad...", ConsoleColor.Green);
                }
                catch (Exception)
                {}
            }
        }
    }
}
