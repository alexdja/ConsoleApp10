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


            var M = new CMethodOfMetering13
            {
                Tr = dIn.Temperature,
                R = dIn.Density_20,
                Tcy = DataIn.Density_Temperature,
                CalibrationTable = dIn.CalibrationTableToString(),
                H = dIn.Level,
                ToolType = ToolTypeEnum.ToolType_Areometer_20
            };

            M.Exec();
            string outputPath = "..\\output.json";
            DataOut dataOut = new DataOut(M.M, M.V, M.Vcy * M.Rcy / M.V_product, M.Rcy);
            dataOut.WriteJsonFile(outputPath);
            System.Threading.Thread.Sleep(1000);    
        }
    }
}
