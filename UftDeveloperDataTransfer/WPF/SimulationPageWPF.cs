using System;
using HP.LFT.SDK;
using HP.LFT.SDK.WPF;
using HP.LFT.Verifications;

namespace UftDeveloperDataTransfer
{
    public class SimulationPageWPF
    {


        IWindow pumpBkpAspenPlusV15AspenONEWindow;

        IWindow upwardCompatibilityWindow;
        IWindow aspenPlusWindow;

        public SimulationPageWPF()
        {

            upwardCompatibilityWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                WindowTitleRegExp = @"Upward Compatibility",
                ObjectName = @"Window_1",
                FullType = @"window"
            });

            aspenPlusWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                WindowTitleRegExp = @"Aspen Plus",
                ObjectName = @"mmd_MMDialog_1",
                FullType = @"window"
            });


        }





        public void VerifySimulationFileIsOpened(string fileName)
        {
            pumpBkpAspenPlusV15AspenONEWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                WindowTitleRegExp = $@"{fileName} - Aspen Plus V15 - aspenONE",
                ObjectName = @"apwnShellWindow",
                FullType = @"window"
            });

            if (upwardCompatibilityWindow.Exists())
            {
                Console.WriteLine("Aspen Plus dialog exists! Performing actions on the dialog.");
                // Do something when the element is found, e.g., interact with controls within this dialog
                // Example: Find a button inside the dialog and click it
                var okButton = upwardCompatibilityWindow.Describe<IButton>(new ButtonDescription { Name = "OK" });
                if (okButton.Exists())
                {
                    okButton.Click();
                }
                else
                {

                    throw new Exception("sfswfewf");
                }
            }

            if (aspenPlusWindow.Exists())
            {
                Console.WriteLine("Aspen Plus dialog exists! Performing actions on the dialog.");
                // Do something when the element is found, e.g., interact with controls within this dialog
                // Example: Find a button inside the dialog and click it
                var okButton = aspenPlusWindow.Describe<IButton>(new ButtonDescription { Name = "Yes" });
                if (okButton.Exists())
                {
                    okButton.Click();
                }
                else
                {


                    throw new Exception("sfswfewf");
                }
            }




            Verify.IsTrue(pumpBkpAspenPlusV15AspenONEWindow.Exists(), "Simulation file was opened successfully");
        }
    }
}
