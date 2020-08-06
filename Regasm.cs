using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DllRegistrar
{
    class Regasm
    {
        enum RegasmOperation
        {
            Register, Unregister
        }

        public static List<string> GetPaths(bool getFor64bit)
        {
            string dotNetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET", getFor64bit ? "Framework64" : "Framework");

            List<string> regasmPaths = new List<string>();

            if (!Directory.Exists(dotNetPath))
                return regasmPaths;
            
            var files = Directory.GetFiles(dotNetPath);
            var regasm_tmp = files.Where(f => Path.GetFileName(f).ToLower() == "regasm.exe");
            foreach (var f in regasm_tmp)
                regasmPaths.Add(f);

            var dirs = Directory.GetDirectories(dotNetPath);
            foreach (var dir in dirs)
            {
                files = Directory.GetFiles(dir);
                regasm_tmp = files.Where(f => Path.GetFileName(f).ToLower() == "regasm.exe");
                foreach (var f in regasm_tmp)
                    regasmPaths.Add(f);
            }

            return regasmPaths;
        }

        public static void Register(string regasmPath, string dllPath)
        {
            menageRegasm(RegasmOperation.Register, regasmPath, dllPath);
        }

        public static void Unregister(string regasmPath, string dllPath)
        {
            menageRegasm(RegasmOperation.Unregister, regasmPath, dllPath);
        }

        private static void menageRegasm(RegasmOperation regasmOperation, string regasmPath, string dllPath)
        {
            string arg = "";
            if (regasmOperation == RegasmOperation.Register)
                arg += dllPath.WrapTo("\"");
            else if (regasmOperation == RegasmOperation.Unregister)
                arg += string.Concat("/unregister", " ", dllPath.WrapTo("\""));

            Process proc = new Process();
            proc.StartInfo.FileName = regasmPath;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.ErrorDataReceived += Proc_OutputDataReceived;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();

            proc.WaitForExit();
        }


        public delegate void OutputDataReceived(string output);
        public static event OutputDataReceived OutputDataReceiverEvent;
        private static void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (OutputDataReceiverEvent != null)
                OutputDataReceiverEvent(e.Data + Environment.NewLine);
        }

        

    }
}
