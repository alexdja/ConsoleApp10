using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp6;
using MM;
using Newtonsoft.Json;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пример
            //Файл находится в ConsoleApp10\ConsoleApp10\bin\Debug
            string pathToInput = "..\\input.json";

            DataIn dIn = JsonConvert.DeserializeObject<DataIn>(File.ReadAllText(pathToInput));
            string outputPath = "..\\output.json";
            DataOut dOut = null;
            Calc.Exec(dIn, outputPath, out dOut);

            System.Threading.Thread.Sleep(1000);    
        }
    }
}
