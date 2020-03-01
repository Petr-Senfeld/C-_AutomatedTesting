using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace TestEshop
{
    [TestFixture]
    // [Parallelizable]

    public class Test_eshop : Base
    {

        IWebDriver driver;

        [Test, Order(1)]
        public void OpenBrowser()
        {
            driver = new ChromeDriver(driver_dir);
            var test = extent.CreateTest("Open browser & click on sign in", "Trying to log in..");

            try
            {
                driver.Url = "https://www.lidl-shop.cz/";
                test.Log(Status.Pass, "Bot has opened the browser..");

            }
            catch (Exception)
            {
                TakeScreenshot("error_Opening browser.jpeg", driver);
                test.Fail("error_Opening browser", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_Opening browser.jpeg").Build());
            }

            try
            {
                IWebElement link = driver.FindElement(By.Id("notLoggedIn"));
                link.Click();
                test.Log(Status.Pass, "Bot has clicked on the Loging link succesfully..");
                TakeScreenshot("Open browser & click on sign in.jpeg", driver);
                test.Pass("Log in was succesfull", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "Open browser & click on sign in.jpeg").Build());
            }
            catch (Exception)
            {
                TakeScreenshot("error_Open browser & click on sign in.jpeg", driver);
                test.Fail("error_Open browser & click on sign in", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_Open browser & click on sign in.jpeg").Build());
            }

            extent.Flush();
        }

        [Test, Order(2)]
        public void SignIn()
        {
            var test = extent.CreateTest("Enter email, password & click on Log in", "Trying to enter username and password..");

            try
            {
                IWebElement email = driver.FindElement(By.Id("email-existing-account-checkout"));
                test.Log(Status.Info, "Bot is trying to write login email..");
                email.SendKeys(username);

                IWebElement heslo = driver.FindElement(By.Id("password-existing-account-checkout"));
                test.Log(Status.Info, "Bot is trying to write password");
                heslo.SendKeys(password);

                TakeScreenshot("Enter email, password & click on Log in.jpeg", driver);
                test.Pass("Email&Password succesfully entered", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "Enter email, password & click on Log in.jpeg").Build());
            }
            catch (Exception)
            {
                TakeScreenshot("error_Enter email, password.jpeg", driver);
                test.Fail("error_Enter email, password", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_Enter email, password.jpeg").Build());
            }

            try
            {
                driver.FindElement(By.Id("chooseaccountbutton-login-checkout")).Click();
                Task.Delay(3000).Wait();

                if (driver.Url.Equals("https://www.lidl-shop.cz/login?error=true"))
                {
                    TakeScreenshot("error_bad username or password.jpeg", driver);
                    test.Fail("error_bad username or password", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_bad username or password.jpeg").Build());
                }
                else
                {
                    TakeScreenshot("Click on Log in.jpeg", driver);
                    test.Pass("Succesfully logged in", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "click on Log in.jpeg").Build());
                }

            }
            catch (Exception)
            {
                TakeScreenshot("error_click on Log in.jpeg", driver);
                test.Fail("error_click_LogIn on Log in", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_click on Log in.jpeg").Build());
            }

            extent.Flush();
        }

        [Test, Order(3)]
        public void ItemToCart()
        {
            var test = extent.CreateTest("Item to cart from Discounts category", "Trying to order..");

            try
            {
                driver.FindElement(By.LinkText("Slevy")).Click();
                test.Log(Status.Info, "Bot is trying to click on Slevy..");
                TakeScreenshot("Click Slevy.jpeg", driver);
                test.Pass("Succesfully clicked on slevy", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "click Slevy.jpeg").Build());
            }

            catch (Exception)
            {
                TakeScreenshot("error_Slevy_link not found.jpeg", driver);
                test.Fail("error_Slevy_link not found", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_Slevy_link not found.jpeg").Build());
            }

            try
            {
                driver.FindElement(By.XPath(".//article/div[2]/div/div[1]/div/a/div/img")).Click();
                TakeScreenshot("Click on product.jpeg", driver);
                test.Pass("Succesfully clicked on product", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "click on product.jpeg").Build());

            }
            catch (Exception)
            {
                TakeScreenshot("error_Product_link not found.jpeg", driver);
                test.Fail("error_Product_link not found", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_Product_link not found.jpeg").Build());
            }

            try
            {
                IWebElement dropdownProduct = driver.FindElement(By.Id("variant0"));
                var selectProduct = new SelectElement(dropdownProduct);
                selectProduct.SelectByValue("P_GROESSE;ClassificationAttributeValueModel (8796258697824@15)");
                TakeScreenshot("Click on selectProduct.jpeg", driver);
                test.Pass("Succesfully selected product", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "click on selectProduct.jpeg").Build());
            }
            catch (Exception)
            {
                TakeScreenshot("error_DropdownProduct_link not found.jpeg", driver);
                test.Fail("error_DropdownProduct_link not found", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_DropdownProduct_link not found.jpeg").Build());
            }

            try
            {
                IWebElement dropdownColor = driver.FindElement(By.Id("variant1"));
                var selectColor = new SelectElement(dropdownColor);
                selectColor.SelectByValue("P_FARBE;ClassificationAttributeValueModel (8796110160480@43)");
                TakeScreenshot("Click on selectProduct.jpeg", driver);
                test.Pass("Succesfully selected color", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "click on selectColor.jpeg").Build());
            }
            catch (Exception)
            {
                TakeScreenshot("error_DropdownColor_link not found.jpeg", driver);
                test.Fail("error_DropdownColor_link not found", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_DropdownColor_link not found.jpeg").Build());
            }

            try
            {
                IWebElement dropdownAmount = driver.FindElement(By.Name("qty"));
                var selectAmount = new SelectElement(dropdownAmount);
                selectAmount.SelectByValue("3");
                TakeScreenshot("Select amount.jpeg", driver);
                test.Pass("Succesfully selected from amount", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "\\Select amount.jpeg").Build());
                
                driver.FindElement(By.Id("addToCartButton")).Click();
                test.Log(Status.Pass, "Product succesfully added to cart..");
            }
            catch (Exception)
            {
                TakeScreenshot("error_DropdownAmount.jpeg", driver);
                test.Fail("error_DropdownAmount", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_DropdownAmount.jpeg").Build());
            }

            extent.Flush();
        }

        [Test, Order(4)]

        public void InCart()
        {

            var test = extent.CreateTest("In Cart", "Checking amount & finishing order..");

            try
            {
                driver.FindElement(By.Id("minibasket")).Click();
            }
            catch (Exception)
            {
                test.Log(Status.Fail, "Cart not found");
            }

            IWebElement amountInBasket = driver.FindElement(By.Id("quantity0"));
            //var amountSelectedInBasket = new SelectElement(amountInBasket);
            test.Log(Status.Info, "Verifying amout of the product");

                if (amountInBasket.GetAttribute("value").Equals("3"))
                {
                    test.Log(Status.Pass, "Amount should be 3 and is " + amountInBasket.GetAttribute("value"));
                    TakeScreenshot("Amount.jpeg", driver);
                    test.Pass("Proof", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "Amount.jpeg").Build());
                }
                else
                {
                    test.Log(Status.Fail, "Amount should be 3 but is " + amountInBasket.GetAttribute("value"));
                    TakeScreenshot("error_badAmount.jpeg", driver);
                    test.Fail("bad Amount in the basket", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "error_badAmount.jpeg").Build());
                }

            try
            {
                driver.FindElement(By.Id("cartCheckout")).Click();
                TakeScreenshot("CheckOut.jpeg", driver);
                test.Pass("CheckoutPage", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "CheckOut.jpeg").Build());

            }
            catch (Exception)
            {
                test.Log(Status.Fail, "Unable to find CheckOut button");
            }

            extent.Flush();

        }

        [Test, Order(5)]

        public void ResetCartAndLogOut()
        {
            var test = extent.CreateTest("Reset Cart&Log Out", "Trying to reset..");

            driver.Navigate().GoToUrl("https://www.lidl-shop.cz/cart");

            try
            {
                driver.FindElement(By.Id("updateQuantityForm0")).Click();
                TakeScreenshot("CartEmtyed.jpeg", driver);
                test.Pass("Cart Emtyed", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "CartEmtyed.jpeg").Build());
            }
            catch
            {
                test.Log(Status.Fail, "Unable to empty Cart");
            }

            try
            {
                driver.FindElement(By.Id("canLogout")).Click();
                TakeScreenshot("LoggedOut.jpeg", driver);
                test.Pass("LoggedOut", MediaEntityBuilder.CreateScreenCaptureFromPath(test_folder_dir + "LoggedOut.jpeg").Build());
            }
            catch
            {
                test.Log(Status.Fail, "Unable to log out");
            }

            extent.Flush();
            driver.Quit();
        }

    }
}

