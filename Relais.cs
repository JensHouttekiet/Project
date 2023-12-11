using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Project
{
    public class Relais
    {

        //public void Open()
        //{
        //    SerialPort serialPort = new SerialPort((string)COMpoortenlijst.SelectedItem, 9600);
        //    serialPort.Open();            // Opent de com poort.
        //}
        public void Aan_Uit()
        {
            SerialPort serialPort = new SerialPort("COM5", 9600);
            serialPort.Write("69");
            serialPort.Write("1");
        }
    }
}