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
            //Файл находится в ConsoleApp6\ConsoleApp6\bin\Debug
            string pathToInput = "..\\input.json";
            //double[,] CalibrationTable = { { 10, 0.997 }, { 11, 1.144 }, { 200, 70.008 }, { 201, 70.405 } };
            //DataIn dIn = new DataIn(520, 30, CalibrationTable, 2000);
            DataIn dIn = JsonConvert.DeserializeObject<DataIn>(File.ReadAllText(pathToInput));
            string outputPath = "..\\output.json";
            DataOut dOut = null;
            Calc.Exec(dIn, outputPath, out dOut);

            //dataOut.WriteJsonFile(outputPath);
            System.Threading.Thread.Sleep(1000);    
        }
    }
}
