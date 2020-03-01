using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace TestEshop
{
    public class Base
    {
        // desired folder name
        static string folderName = "_AutomativeTest" + DateTime.Now.ToString("HH-mm-ss_dd-MM-yyyy");

        // path to desired location to save tests
        public static string test_folder_dir = "D:\\Testing_reports\\" + folderName + "\\";

        // path to "chromedriver.exe" (in the browser go to 3dots => help => about)
        public static string driver_dir = "D:\\chrome_driver\\";

        // set your registered username and password
        public static string username = "USERNAME";
        public static string password = "PASSWORD";

        public ExtentReports extent = ReportManager.GetInstance();
        public void TakeScreenshot(string filename, IWebDriver driver)
        {
            Task.Delay(1000).Wait();
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(test_folder_dir + filename);
        }
    }
}