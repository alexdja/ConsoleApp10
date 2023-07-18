using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Web;

namespace ConsoleApp6
{
    //Класс для сериализации в выходной json файл
    [Serializable]
    internal class DataOut
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double Density_15 { get; set; }
        public double Density_WorkCond { get; set; }
        public string Result { get; set; }
        public string Error { get; set; }
        public string Date { get; set; }
        public DataOut(double w, double v, double d_wс, double d_15)
        {
            Weight = w;
            Density_15 = d_15;
            Volume = v;
            Density_WorkCond = d_wс;
            Error = "";
            Result = "";
            Date = "";
        }
        public DataOut(string result, string error, string date)
        {
            Error = error;
            Result = result;
            Date = date;
        }
        public void WriteJsonFile(string path) {
            string jsonString = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, jsonString);
        }
    }
}
