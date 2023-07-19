using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    //Класс для чтения в входного json файла
    [Serializable]
    internal class DataIn
    {
        public const int Density_Temperature = 20;
        public double Density_20 { get; set; }
        public double Temperature { get; set; }
        public double[,] CalibrationTable { get; set; }
        public double Level_full { get; set; }
        public DataIn() { }
        public DataIn(double d, double t, double[,] CT, double lvl)
        {
            Density_20 = d;
            Temperature = t;
            CalibrationTable = CT;
            Level_full = lvl;
        }
        public string FormatCalibrationTable()
        {
            try
            {
                int level = (int)(Level_full / 10);
                return CalibrationTable[level, 0] + "=" + CalibrationTable[level, 1] + "\r\n" +
                       CalibrationTable[level + 1, 0] + "=" + CalibrationTable[level + 1, 1];
            }
            catch
            {
                throw new Exception("Ошибка во входных данных");
            }
        }
    }
}
