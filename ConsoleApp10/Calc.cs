using ConsoleApp6;
using MM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Calc
    {
        public static string Exec(DataIn dataIn, string outputPath, out DataOut dataOut) 
        {
            var M = new CMethodOfMetering13();
            try
            {
                M.Tr = dataIn.Temperature;
                M.R = dataIn.Density_20;
                M.Tcy = DataIn.Density_Temperature;
                M.CalibrationTable = dataIn.FormatCalibrationTable();
                M.H = dataIn.Level_full;
                M.ToolType = ToolTypeEnum.ToolType_Areometer_20;
                M.Exec();
                dataOut = new DataOut(M.M, M.V, M.Rv, M.Rcy);
                dataOut.WriteJsonFile(outputPath);
            } 
            catch (Exception ex)
            {
                dataOut = null;
                Console.WriteLine("Ошибка :" + ex.ToString());
                Console.WriteLine(M.ResultDetail);
            }
            Console.WriteLine(M.ResultDetail);
            return M.ResultDetail;
        }
    }
}
