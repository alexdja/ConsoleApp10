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
        public double Level { get; set; }
        public DataIn() { }
        public DataIn(double d, double t, double[,] CT, double lvl)
        {
            Density_20 = d;
            Temperature = t;
            if (CT.GetLength(1) > 2)
            {
                throw new Exception("Invalid Calibration Table Length");
            }
            CalibrationTable = CT;
            Level = lvl;
        }
        public string CalibrationTableToString()
        {
            string CalibrTbl = "";
            for (int i = 0; i < CalibrationTable.GetLength(0); i++)
            {
                CalibrTbl += CalibrationTable[i, 0] + "=" + CalibrationTable[i, 1];
                if (i != CalibrationTable.GetLength(0) - 1)
                {
                    CalibrTbl += "\r\n";
                }
            }
            return CalibrTbl;
        }
    }
}
