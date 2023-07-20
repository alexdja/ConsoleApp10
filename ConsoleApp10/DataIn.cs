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
        public const int Target_Temperature = 15;
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
            int level = (int)(Level_full / 10);
            try
            {
                return CalibrationTable[level, 0] + "=" + CalibrationTable[level, 1] + "\r\n" +
                       CalibrationTable[level + 1, 0] + "=" + CalibrationTable[level + 1, 1];
            }
            catch
            {
                if (CalibrationTable[CalibrationTable.GetLength(0) - 1, 0] < level)
                {
                    throw new Exception("Введенный уровень превышает все значения калибровочной таблицы");
                }
                if (CalibrationTable[CalibrationTable.GetLength(0) - 1, 0] == level)
                {
                    throw new Exception("Введенный уровень равен максимальному значению калибровочной таблицы");
                }
                throw new Exception("Ошибка в калибровочной таблице");
            }
        }
    }
}
