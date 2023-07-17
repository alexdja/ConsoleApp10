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
            double tmp = Level_full / 10;
            int i;
            for (i = 0; i < CalibrationTable.GetLength(0); i++)
            {
                if (i != 0 && CalibrationTable[i, 0] != CalibrationTable[i - 1, 0] + 1)
                {
                    throw new Exception("Ошибка в калибровочной строке: Элементы должны отличаться на 1 мм");
                }
                if (tmp <= CalibrationTable[i, 0])
                {
                    string str = CalibrationTable[i, 0] + "=" + CalibrationTable[i, 1];
                    if (i + 1 == CalibrationTable.GetLength(0))
                    {
                        throw new Exception("Ошибка в калибровочной строке: Отсутствует элемент " + (tmp + 1));
                    }
                    if (CalibrationTable[i + 1, 0] != tmp + 1)
                    {
                        throw new Exception("Ошибка в калибровочной строке: Ошибка в " + (i + 1) + "-й строке");
                    }
                    return str + "\r\n" + CalibrationTable[i + 1, 0] + "=" + CalibrationTable[i + 1, 1];
                }
            }
            throw new Exception("Ошибка в калибровочной строке: Отсутствуют элементы" + tmp + " и " + (tmp + 1));
        }
    }
}
