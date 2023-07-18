using ConsoleApp6;
using MM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Calc
    {
        public static string errorFilePath = "..\\Error\\error.json";
        public static void Exec(DataIn dataIn, string outputPath, out DataOut dataOut) 
        {
            var M = new CMethodOfMetering13();
            dataOut = null;
            try
            {
                M.Tr = dataIn.Temperature;
                M.R = dataIn.Density_20;
                M.Tcy = DataIn.Density_Temperature;
                M.CalibrationTable = dataIn.FormatCalibrationTable();
                M.H = dataIn.Level_full;
                M.ToolType = ToolTypeEnum.ToolType_Areometer_20;
                M.Exec();
                Console.WriteLine(M.ResultDetail);
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка :" + ex.Message);
                Console.WriteLine(M.ResultDetail);

                string jsonString = "{ Result: \"" + M.ResultDetail + "\", Error: \"" + ex.Message + "\", Date: \"" + System.DateTime.Now.ToString() +"}";
                File.WriteAllText(errorFilePath, jsonString);
                return;
            }
            if (M.Result != 0)
            {
                string jsonString = "{ Result: \"" + M.ResultDetail + "\", Error: \"\", Date: \"" + System.DateTime.Now.ToString() + "\"}";
                File.WriteAllText(errorFilePath, jsonString);
                return;
            }
            File.WriteAllText(errorFilePath, "{ Result: \"\", Error: \"\", Date:  \"\" }");
            dataOut = new DataOut(M.M, M.V, M.Rv, M.Rcy);
            dataOut.WriteJsonFile(outputPath);
        }
    }
}
