using System;
using System.Diagnostics;

namespace UftDeveloperDataTransfer
{
    class Utility
    {

        public void launchExe(string exePath)
        {


            // Create a new process
            Process appProcess = new Process { StartInfo = { FileName = exePath } };
            appProcess.Start();
        }
    }
}
