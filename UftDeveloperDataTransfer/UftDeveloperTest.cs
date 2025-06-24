

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

            OpenSimulationPageWPF openSimulationPage = new OpenSimulationPageWPF();

            openSimulationPage.VerifyAspenPlusIsOpened();

        }

        [TestMethod]
        public void _002_TestOpenSimulationFile()
        {

            OpenSimulationPageWPF openSimulationPage = new OpenSimulationPageWPF();
            OpenDialogStdWin openDialog = new OpenDialogStdWin();
            SimulationPageWPF simulationPage = new SimulationPageWPF();



            openSimulationPage.LaunchOpenFileWindow();

            openDialog.OpenSimulationFileInGivenPath(@"C:\Users\gutierrj\source\repos\datatransfer-ProII\Aspen Plus Automation Transfer\Aspen Plus Files\Pump&Pump Curves", "Pump.bkp");

            //openDialog.OpenSimulationFileInGivenPath(@"C:\Users\gutierrj\source\repos\datatransfer-ProII\Aspen Plus Automation Transfer\Aspen Plus Files\Heater&Heat Exchange Side", "Heater_Cooler.bkp");

            simulationPage.VerifySimulationFileIsOpened("Pump.bkp");

        }



        [TestMethod]
        public void Test()
        {


            SimulationPageWPF simulationPage = new SimulationPageWPF();
            simulationPage.Test();


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
