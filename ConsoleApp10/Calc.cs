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
        public static DataOut Exec(DataIn dataIn, string outputPath) 
        {
            DataOut dataOut = null;
            //Если будет исключение в CMethodOfMetering13.Exec()
            //или в DataIn.FormatCalibrationTable(),
            //то try-catch ее поймает и выведет в файл
            string Result = "";
            try
            {
                var M = new CMethodOfMetering13();

                M.Tr = dataIn.Temperature;
                M.R = dataIn.Density_20;
                M.Tcy = DataIn.Density_Temperature;
                M.CalibrationTable = dataIn.FormatCalibrationTable();
                M.H = dataIn.Level_full;
                M.ToolType = ToolTypeEnum.ToolType_Areometer_20;
                M.Exec();
                Console.WriteLine(M.ResultDetail);
                Result = M.ResultDetail;

                //Если у CMethodOfMetering13.Exec() проблема
                //с вычислениями из-за некорректных данных,
                //то ее поймает if и так же выведет в файл
                if (M.Result != 0)
                {
                    dataOut = new DataOut(Result, "", System.DateTime.Now.ToString());
                }
                else dataOut = new DataOut(M.M, M.V, M.Rv, M.Rcy);
                dataOut.WriteJsonFile(outputPath);
                return dataOut;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка :" + ex.Message);
                Console.WriteLine(Result);
                string str = Result != null ? Result : "Вычисления не выполнены";
                dataOut = new DataOut(str, ex.Message, System.DateTime.Now.ToString());
                dataOut.WriteJsonFile(outputPath);
                return dataOut;
            }
        }
    }
}
