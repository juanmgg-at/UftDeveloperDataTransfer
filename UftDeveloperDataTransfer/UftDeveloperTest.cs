

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static UftDeveloperDataTransfer.OpenSimulationPageWPF;


namespace UftDeveloperDataTransfer
{
    [TestClass]
    public class UftDeveloperTest : UnitTestClassBase<UftDeveloperTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }




        [TestMethod]
        public void _001_TestLaunchAspenPlus()
        {

            string exePath = @"C:\Program Files\AspenTech\Aspen Plus V15.0\GUI\Xeq\AspenPlus.exe";

            Utility utility = new Utility();
            utility.launchExe(exePath);


            VerifyAspenPlusIsOpened();

        }

        [TestMethod]
        public void _002_TestOpenSimulationFile()
        {

            LaunchOpenFileWindow();

        }



        [TestMethod]
        public void _003_TestOpenSimFile()
        {

            OpenDialogStdWin openDialog = new OpenDialogStdWin();



            openDialog.OpenSimulationFileInGivenPath(@"C:\Users\gutierrj\source\repos\datatransfer-ProII\Aspen Plus Automation Transfer\Aspen Plus Files\Pump&Pump Curves", "Pump.bkp");

            VerifySimulationFileIsOpened("Pump.bkp");
        }





        [TestCleanup]
        public void TestCleanup()
        {


        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }
    }
}
