
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using UnlDiagram.FIleService;

namespace UnlDiagram
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Manager.Save<Car>(new Car());

            Car a = new Car();






            FileManager.WriteToXmlFile(a);

            Application.Run(new Form1());
        }
    }
}