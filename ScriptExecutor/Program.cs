using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PhotoStore.BusinessLogic;
namespace ScriptExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            blUtility.ExecuteScripts(Application.StartupPath);
        }
    }
}
