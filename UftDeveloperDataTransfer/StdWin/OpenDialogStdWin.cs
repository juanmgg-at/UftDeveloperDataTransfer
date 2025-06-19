using HP.LFT.SDK;
using HP.LFT.SDK.StdWin;
using System;

namespace UftDeveloperDataTransfer
{
    public class OpenDialogStdWin
    {

        IDialog openDialog;
        IToolBar addressBandToolbarToolBar;
        IEditField editEditField;
        IEditField fileNameEditField;
        IButton openButton;


        public OpenDialogStdWin()
        {
            openDialog = Desktop.Describe<IDialog>(new DialogDescription
            {
                NativeClass = @"#32770",
                Text = @"Open",
                IsOwnedWindow = true,
                IsChildWindow = false
            });

            addressBandToolbarToolBar = openDialog.Describe<IToolBar>(new ToolBarDescription
            {
                NativeClass = @"ToolbarWindow32",
                Text = @"Address band toolbar"
            });

            editEditField = openDialog.Describe<IEditField>(new EditFieldDescription
            {
                NativeClass = @"Edit",
                WindowId = 41477
            });

            fileNameEditField = openDialog
            .Describe<IEditField>(new EditFieldDescription
            {
                NativeClass = @"Edit",
                AttachedText = @"File &name:"
            });

            //var fileNameEditField = Desktop.Describe<IWindow>(new WindowDescription
            //{
            //    WindowTitleRegExp = @"<No Document> - Aspen Plus V15 - aspenONE",
            //    ObjectName = @"apwnShellWindow",
            //    FullType = @"window"
            //})
            //.Describe<IDialog>(new DialogDescription
            //{
            //    NativeClass = @"#32770",
            //    Text = @"Open",
            //    IsOwnedWindow = true,
            //    IsChildWindow = false
            //})
            //.Describe<IEditField>(new EditFieldDescription
            //{
            //    NativeClass = @"Edit",
            //    AttachedText = @"File &name:"
            //});

            openButton = openDialog.Describe<IButton>(new ButtonDescription
            {
                NativeClass = @"Button",
                Text = @"&Open"
            });

        }

        public void MoveToGivenPath(string filePath)
        {
            openDialog.Activate();


            addressBandToolbarToolBar.GetButton("1").Press();


            editEditField.SendKeys(filePath);


            editEditField.SendKeys(HP.LFT.SDK.Keys.Return);
        }

        public void OpenGivenFile(string fileName)
        {
            fileNameEditField.SendKeys(fileName);

            if (!fileNameEditField.Exists()) throw new Exception("");
            openButton.Click();
        }

        public void OpenSimulationFileInGivenPath(string filePath, string fileName)
        {

            // Move to specific path 

            MoveToGivenPath(filePath);

            // Select file in specific path 

            OpenGivenFile(fileName);




        }


    }
}
