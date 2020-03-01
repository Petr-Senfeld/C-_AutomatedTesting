using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestEshop
{
    public class ReportManager : Base
    {
        private static ExtentReports extent;
        public static ExtentReports GetInstance()
        {
            var reporter = new ExtentHtmlReporter(test_folder_dir);

            if (extent == null)
            {
                extent = new ExtentReports();
                extent.AttachReporter(reporter);

            }
            return extent;
        }
    }
}
