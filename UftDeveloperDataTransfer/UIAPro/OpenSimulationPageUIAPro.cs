using System;
using HP.LFT.SDK;
using HP.LFT.SDK.UIAPro;
using HP.LFT.Verifications;

namespace UftDeveloperDataTransfer
{
    public static class OpenSimulationPageUIPro
    {



        public static void VerifyAdditionalWindowsIsOpen()
        {
            var aspenPlusMainWindow = Desktop.Describe<IWindow>(new WindowDescription
            {
                ProcessName = @"AspenPlus",
                Name = @"<No Document> - Aspen Plus V15 - aspenONE",
                Path = @"Window",
                SupportedPatterns = new string[] { @"LegacyIAccessible", @"SynchronizedInput", @"Transform", @"Value", @"Window" },
                FrameworkId = @"WPF",
                ControlType = @"Window",
                AutomationId = @"apwnShellWindow"
            });

            // Describe the child window (Aspen Plus dialog/sub-window)
            var aspenPlusDialog = aspenPlusMainWindow.Describe<IWindow>(new WindowDescription
            {
                ProcessName = @"AspenPlus",
                Name = @"Aspen Plus",
                Path = @"Window;Window",
                SupportedPatterns = new string[] { @"LegacyIAccessible", @"SynchronizedInput", @"Transform", @"Window" },
                FrameworkId = @"WPF",
                ControlType = @"Window",
                AutomationId = @"mmd_MMDialog_1"
            });

            // Now, use the Exists() method to check if the element is found
            if (aspenPlusDialog.Exists())
            {
                Console.WriteLine("Aspen Plus dialog exists! Performing actions on the dialog.");
                // Do something when the element is found, e.g., interact with controls within this dialog
                // Example: Find a button inside the dialog and click it
                var okButton = aspenPlusDialog.Describe<IButton>(new ButtonDescription { Name = "Yes" });
                if (okButton.Exists())
                {
                    okButton.Click();
                }
            }
            else
            {
                Console.WriteLine("Aspen Plus dialog does NOT exist. Performing alternative actions.");
                // Do something else when the element is not found
                // Example: Log an error, take a screenshot, or try a different approach
                // Desktop.TakeScreenshot("AspenPlusDialogNotFound.png");
            }

            // You can still get the description if needed, but it's not directly related to the existence check.
            // var description = aspenPlusMainWindow.GetDescription();
            // Console.WriteLine(description.ToString());

        }
    }
}
