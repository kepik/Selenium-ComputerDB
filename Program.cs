using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace automationweb
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the reference for our browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            driver.Manage().Window.Maximize(); //maximize browser window
            Thread.Sleep(2000); //time is in milliseconds

            // Case 1: Add a new record
            //click Add a New Computer button
            driver.FindElement(By.Id("add")).Click();

            driver.FindElement(By.Id("name")).SendKeys("Test New Computer");
            driver.FindElement(By.Id("introduced")).SendKeys("2000-01-01");
            driver.FindElement(By.Id("discontinued")).SendKeys("2010-12-20");
            driver.FindElement(By.Id("company"))
                              .FindElement(By.CssSelector("#company > option:nth-child(18)")).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.XPath("/html/body/section/form/div/input")).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.XPath("/ html / body / header / h1 / a")).Click(); //back to main page
            Thread.Sleep(1500);

            // Case 2: View and update the computer details
            //define search textbox and button
            IWebElement searchbox = driver.FindElement(By.Id("searchbox"));
            IWebElement searchbutton = driver.FindElement(By.Id("searchsubmit"));

            searchbox.Click();              //search the computer
            searchbox.SendKeys("ACE");

            searchbutton.Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr[1]/td[1]/a")).Click();
            Thread.Sleep(1000);

            //edit the company value
            driver.FindElement(By.Id("company"))
                              .FindElement(By.CssSelector("#company > option:nth-child(4)")).Click();
            Thread.Sleep(1500);

            //click the Save this Computer button
            driver.FindElement(By.XPath("//*[@id=\"main\"]/form[1]/div/input")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/ html / body / header / h1 / a")).Click(); //back to main page
            Thread.Sleep(1500);

            // Case 3: delete a record
            driver.FindElement(By.XPath("//*[@id=\"searchbox\"]")).Click();              //search the computer
            driver.FindElement(By.XPath("//*[@id=\"searchbox\"]")).SendKeys("ASCI Blue Mountain");

            driver.FindElement(By.XPath("//*[@id=\"searchsubmit\"]")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr[1]/td[1]/a")).Click();
            Thread.Sleep(1000);

            //click the Delete this Computer button
            driver.FindElement(By.XPath("//*[@id=\"main\"]/form[2]/input")).Click();
            Thread.Sleep(2000);

            driver.Quit();
        }
    }



}