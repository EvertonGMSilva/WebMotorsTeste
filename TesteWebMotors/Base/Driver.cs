using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TesteWebMotors;

namespace Automation.Base
{
    [Binding]
    public class Driver
    {
        public static IWebDriver driver;
        public static string URL;

        public void SetImplicityWait(int seconds)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
            catch (Exception)
            {
                throw;
            }            
        }        
        public static IWebDriver GetDriver()
        {
            if (driver == null)
                driver = AccessWebSite();

            return driver;
        }
        [BeforeScenario]
        public static IWebDriver AccessWebSite()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver();            
            chromeOptions.AddArguments("--incognito");
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--window-size=1440x900");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(230);
            driver.Navigate().GoToUrl("https://www.webmotors.com.br/");            

            return driver;
        }

        [AfterScenario]
        public void CloseNavigate()
        {
            //driver.Close();
            driver.Quit();
        }

        public string GetElementText(By by)
        {
            return driver.FindElement(by).Text;
        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao clicar no elemento.\n{e.Message}");
            }
        }
        public IWebElement ElementeExiste(By by)
        {
            try
            {
                IWebElement webElement = driver.FindElement(by);
                return webElement;
            }
            catch (Exception e)
            {
                throw new Exception($"Elemento não encontrado\n{e.Message}");
            }
        }

        public void SenKeys(By by, string text)
        {
            try
            {
                ElementeExiste(by).SendKeys(text);
            }
            catch
            {
                throw;
            }
        }
        public bool ElementExiste(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ValidAssertIsTrue(By by)
        {
            try
            {
                Assert.IsTrue(ElementExiste(by));
            }
            catch (ElementNotVisibleException e)
            {
                throw new ElementNotVisibleException($"Erro ao encontrar elemento.\n{e.Message}");
            }
        }
        public void ValidAssertAreEqual(object xpath, object value)
        {
            try
            {
                Assert.AreEqual(xpath, value);
            }
            catch (ElementNotVisibleException e)
            {
                throw new ElementNotVisibleException($"Erro ao encontrar elemento.\n{e.Message}");
            }            
        }
        public int GetWebElements(By by)
        {
            try
            {
                IList<IWebElement> elements;
                elements =  driver.FindElements(by);
                return elements.Count;
            }
            catch(Exception e)
            {
                throw new Exception($"Erro ao obter elemento web.\n{e.Message}");
            }
        }
    }
}
