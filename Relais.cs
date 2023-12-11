using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows;

namespace Project
{
    public class Relais
    {
        public string Poort { get; set; }
        private SerialPort serialPort;
        byte open_dicht = 1;
        byte aangesloten = 0;   


        public void Open()
        {
            serialPort = new SerialPort(Poort, 9600);
            serialPort.Open();            // Opent de com poort.
            aangesloten = 1;
        }

        public void Sluit()
        {
            serialPort.Close();           // Sluit de com poort.
            aangesloten = 0;
        }

        public void Aan_Uit()
        {
            if (aangesloten == 1)
                if (open_dicht == 1)
                {
                    serialPort.Write("1");  // Schakelt relais aan.
                    open_dicht = 2;         
                }
                else
                {
                    serialPort.Write("2");  // Schakelt relais uit.
                    open_dicht = 1;
                }
            else
            {
                MessageBox.Show("Kies een COM poort.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}