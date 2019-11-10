using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace BlockControl
{
    public class Program
    {

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        static void Main()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);//hide
            //ShowWindow(handle, SW_SHOW);//show



            Console.ReadKey();
        }
    }
}