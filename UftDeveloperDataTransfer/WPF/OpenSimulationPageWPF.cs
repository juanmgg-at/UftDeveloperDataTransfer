using System;
using HP.LFT.SDK;
using HP.LFT.SDK.WPF;
using HP.LFT.Verifications;

namespace UftDeveloperDataTransfer
{
    public static class OpenSimulationPageWPF
    {


        public static void LaunchOpenFileWindow()
        {
            var noDocumentAspenPlusV15AspenONEWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                FullType = @"window",
                ObjectName = @"apwnShellWindow",
                WindowTitleRegExp = @"<No Document> - Aspen Plus V15 - aspenONE"
            });

            

            noDocumentAspenPlusV15AspenONEWindow.Activate();

            var openButton = noDocumentAspenPlusV15AspenONEWindow.Describe<IButton>(new ButtonDescription
            {
                ObjectName = @"OpenCase",
                Text = @"Open"
            });
            openButton.Click();

        }

        public static void VerifyAspenPlusIsOpened()
        {
            var noDocumentAspenPlusV15AspenONEWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                FullType = @"window",
                ObjectName = @"apwnShellWindow",
                WindowTitleRegExp = @"<No Document> - Aspen Plus V15 - aspenONE"
            });




            Verify.IsTrue(noDocumentAspenPlusV15AspenONEWindow.Exists());
        }


        public static void VerifySimulationFileIsOpened(string fileName)
        {
            var pumpBkpAspenPlusV15AspenONEWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                WindowTitleRegExp = $@"{fileName} - Aspen Plus V15 - aspenONE",
                ObjectName = @"apwnShellWindow",
                FullType = @"window"
            });


            Verify.IsTrue(pumpBkpAspenPlusV15AspenONEWindow.Exists(), "Simulation file was opened successfully");
        }
    }
}
