
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using UnlDiagram.FIleService;
using UnlDiagram.Models;
using UnlDiagram.Models.Enums;
using UnlDiagram.Models.Parameters;
using UnlDiagram.Views;

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

            //Car a = new Car();

            //ClassVariable b = new ClassVariable("Name", VariablesTypes._string, AccessModifiers._public);

            //MethodVariable c = new MethodVariable("GetAuta", VariablesTypes._float, AccessModifiers._public);
            //c.Parameters.Add(new Variable("Barva","Color"));
            //c.Parameters.Add(new Variable("PocetKol",VariablesTypes._int));

            //FileManager.WriteToXmlFile(c);

            ////FileManager.WriteToXmlFile(b);

            //var necob = FileManager.ReadFromXmlFile<MethodVariable>(
            //    @"C:\Users\jboha\Source\Repos\Jbohacek\UnlDiagram\UnlDiagram\TestFiles\Test_4375_22.09.2023.xml");
            
            //Debug.WriteLine(necob);

            ////var neco = FileManager.ReadFromXmlFile<ClassVariable>(
            //    //@"C:\Users\jboha\Source\Repos\Jbohacek\UnlDiagram\UnlDiagram\TestFiles\Test_6133_22.09.2023.xml");

            Application.Run(new MainForm());
        }
    }
}