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
            int level = (int)(Level_full / 10);
            //Поиск подходящего элемента
            int i = Array.IndexOf(CalibrationTable, level);

            //Проверки на наличие нужных элементов
            if (i < 0) 
            {
                //Если пришел уровень выше резервуара, то в таблице не будет подходящего значения
                //и функция выдаст исключение
                throw new Exception("Ошибка в калибровочной строке: Отсутствуют элемент " + level);
            }
            if (i + 1 == CalibrationTable.GetLength(0))
            {
                throw new Exception("Ошибка в калибровочной строке: Отсутствует элемент " + (level + 1));
            }
            if (CalibrationTable[i + 1, 0] != level + 1)
            {
                throw new Exception("Ошибка в калибровочной строке: Ошибка в " + (i + 1) + "-й строке");
            }
            return CalibrationTable[i, 0] + "=" + CalibrationTable[i, 1] + "\r\n" + 
                   CalibrationTable[i + 1, 0] + "=" + CalibrationTable[i + 1, 1];
        }
    }
}
