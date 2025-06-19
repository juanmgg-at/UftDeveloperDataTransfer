using System;
using HP.LFT.SDK;
using HP.LFT.SDK.WPF;
using HP.LFT.Verifications;

namespace UftDeveloperDataTransfer
{
    public class OpenSimulationPageWPF
    {


        IWindow noDocumentAspenPlusV15AspenONEWindow;
        IButton openButton;


        public OpenSimulationPageWPF()
        {

            noDocumentAspenPlusV15AspenONEWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                FullType = @"window",
                ObjectName = @"apwnShellWindow",
                WindowTitleRegExp = @"<No Document> - Aspen Plus V15 - aspenONE"
            });


            openButton = noDocumentAspenPlusV15AspenONEWindow.Describe<IButton>(new ButtonDescription
            {
                ObjectName = @"OpenCase",
                Text = @"Open"
            });

            

        }


        public void LaunchOpenFileWindow()
        {


            noDocumentAspenPlusV15AspenONEWindow.Activate();


            openButton.Click();

        }

        public void VerifyAspenPlusIsOpened()
        {
           
            Verify.IsTrue(noDocumentAspenPlusV15AspenONEWindow.Exists());
        }



    }
}
