using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DllRegistrar
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs().Length > 0)
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine();
                processArguments();
                SendKeys.SendWait("{ENTER}");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        

        private static void processArguments()
        {
            var args = Environment.GetCommandLineArgs();
            string command = args[1].ToLower();

            string bestRgsm = "";
            if (args.Length > 2 ||
                command == "-h")
            {
                // args ok
                bestRgsm = Regasm.FindBestRegasm(Regasm.GetPaths(false));
            }
            else
                command = "";

            Console.WriteLine("---=== DllRegistrar ===---");
            switch (command)
            {
                case "-r": //register
                    if (string.IsNullOrEmpty(bestRgsm))
                        Console.WriteLine("Not found best RegAsm.");
                    else
                    {
                        Regasm.OutputDataReceiverEvent += Console.Write;
                        Regasm.Register(bestRgsm, args[2]);
                    }
                    break;

                case "-u": //unregister
                    if (string.IsNullOrEmpty(bestRgsm))
                        Console.WriteLine("Not found best RegAsm.");
                    else
                    {
                        Regasm.OutputDataReceiverEvent += Console.Write;
                        Regasm.Unregister(bestRgsm, args[2]);
                    }
                    break;

                case "-h": //help
                    #region cmd help
                    Console.WriteLine();
                    Console.WriteLine("-r Specifies dll to registration.");
                    Console.WriteLine("-u Specified dll to unregistration.");
                    Console.WriteLine("-h Displays this help.");
                    Console.WriteLine();
                    Console.WriteLine("Examples: ");
                    Console.WriteLine("DllRegistrar.exe -r \"C:\\Users\\Dawid\\Desktop\\mylib.dll\"");
                    Console.WriteLine("DllRegistrar.exe -u \"C:\\Users\\Dawid\\Desktop\\mylib.dll\"");
                    #endregion
                    break;

                default:
                    Console.WriteLine("The syntax of the command is incorrect.");
                    Console.WriteLine("Try -h for help.");
                    break;
            }

        }

    }
}
