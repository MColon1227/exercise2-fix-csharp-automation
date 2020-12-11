using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;

using System;
using Assert = NUnit.Framework.Assert;

namespace exercise2_fix_csharp_automation
{
  public class UnitTest1
  {
    [Test]
    public void FacebookSingUp()
    {
      FacebookPage loginPage = new FacebookPage();
      // Go to the "Facebook" homepage 
      loginPage.GoToLogin();


      // Validate text 
      string actualTitle = loginPage.GetTitle();
      var expectedTitle = "Facebook - Log In or Sign Up";
      Assert.AreEqual(expectedTitle, actualTitle);

      //Fill up the sing up section
      
      loginPage.TypeInfoUser();
      loginPage.Wait(5);

      //Select different default birthday 
      loginPage.ClickBirthdayButton();
      loginPage.Wait(5);

      //Select Female gender input
      loginPage.SelectFemale();
      loginPage.Wait(5);

      //Verify text ----> Connect with friends and the world around you on Facebook.
      loginPage.VerifyTexAssert();
      loginPage.Wait(5);
      loginPage.Close();
    }
  }
}
