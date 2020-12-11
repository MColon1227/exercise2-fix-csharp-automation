using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace exercise2_fix_csharp_automation
{
  class FacebookPage
  {
    IWebDriver _driver = new ChromeDriver(@"C:\Users\marisol.colon\Downloads\chromedriver_win32");

    string baseUrl = "https://www.facebook.com/";

    //Create Account Button
    By CreateAccountButton = By.CssSelector("form#u_0_a  a[role='button']");
    //SingUP fill info
    By Firstname = By.Id("u_1_b");
    By Lastname = By.Id("u_1_d");
    By Email = By.Name("reg_email__");
    By ReEnterEmail = By.Name("reg_email_confirmation__");
    By Password = By.Name("reg_passwd__");

    //Select Birthday options input
    By month_button = By.CssSelector("#month > option:nth-child(4)");
    By date_button = By.CssSelector("#day > option:nth-child(16)");
    By year_button = By.CssSelector("#year > option:nth-child(39)");

    //Select Gender input
    By Female = By.CssSelector("span:nth-of-type(1) > ._58mt");
    By Male = By.CssSelector("span:nth-of-type(2) > ._58mt");

    //Verify text ----> Connect with friends and the world around you on Facebook.
    //Also I add extra step to close the modal
    By CloseModal = By.CssSelector("._8ien > img");
    By VerifyText = By.CssSelector("._8eso");

    public void GoToLogin()
    {
      _driver.Navigate().GoToUrl(baseUrl);
    }
    public void Wait(int seconds)
    {
      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
      Console.WriteLine("Wait option");
    }
    public string GetTitle()
    {
      return _driver.Title;
    }

    public void TypeInfoUser()
    {
      _driver.FindElement(CreateAccountButton).Click();
      Wait(5);
      _driver.FindElement(Firstname).SendKeys("Marisol");
      _driver.FindElement(Lastname).SendKeys("Colon");
      _driver.FindElement(Email).SendKeys("marisol.colon@test.com");
      _driver.FindElement(ReEnterEmail).SendKeys("marisol.colon@test.com");
      _driver.FindElement(Password).SendKeys("password");
    }
    public void ClickOption(By selector)
    {
      _driver.FindElement(selector).Click();
      Console.WriteLine("Click option");
    }
    public void WaitToBeClickable(By selector)
    {
      WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
      IWebElement firstResult = wait.Until(e => e.FindElement(selector));
    }
    public void ClickBirthdayButton()
    {
      //Wait for element visible
      WaitToBeClickable(month_button);

      ClickOption(month_button);
      ClickOption(date_button);
      ClickOption(year_button);

    }
    public void SelectFemale()
    {
      WaitToBeClickable(Female);
      ClickOption(Female);
    }

    public void VerifyTexAssert()
    {
      ClickOption(CloseModal);

      string actualText = _driver.FindElement(VerifyText).Text;
      Assert.IsTrue(actualText.Contains("Connect with friends and the world around you on Facebook."), actualText + " doesn't contains 'Connect with friends and the world around you on Facebook.'");
      Console.WriteLine("Assert Success");
    }

    public void Close()
    {
      Wait(5);
      _driver.Close();
    }

  }
}
