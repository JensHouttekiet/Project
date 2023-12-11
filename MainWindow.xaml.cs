using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Relais relais;

        bool open;          // Maakt dat de poort niet twee keer open kan.
        bool keuze;         // Maakt dat de niet open kan voordat een com poort gekozen is.
        public MainWindow()
        {
            InitializeComponent();
            relais = new Relais();
        }

        private void Relais_Click(object sender, RoutedEventArgs e)
        {
            relais.Aan_Uit();
        }

        private void CheckPorts_Click(object sender, RoutedEventArgs e)
        {
            String[] Ports = SerialPort.GetPortNames();    // checkt welke poorten verbonden zijn.
            COMpoortenlijst.Items.Clear();                 // Verwijderd de compoorten die al in de lijst staan.
            foreach (string poort in Ports)                // Elke verbonden poort word in een string geplaatst.
            {
                COMpoortenlijst.Items.Add(poort);          // Zet de poorten in de list box.
            }
            COMpoortenlijst.SelectedIndex = 0;             // Maakt zodat er zeker een poort word gekozen.
            keuze = true;
        }
        
        public void OpenPoort_Click(object sender, RoutedEventArgs e)
        {
            if (keuze == true)                  // Als een com poort gekozen is zal de open knop werken.
                if (open == false)              // Als open nog niet gedrukt werkt zal de com poort worden geopent.
                {
                    SerialPort serialPort = new SerialPort((string)COMpoortenlijst.SelectedItem, 9600);
                    serialPort.Open();            // Opent de com poort.
                    open = true;                  // Maakt dat de open poort niet opnieuw kan geopent worden voordat hij gesloten is.
                }
                else
                {
                    MessageBox.Show("COM poort is al open.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation); // Maakt dat gebruiker weet dat com poort al open is.
                }
                else
                    MessageBox.Show("Kies een COM poort.", "ERROR", MessageBoxButton.OK , MessageBoxImage.Exclamation);  // Maakt dat gebruiker weet dat je nog een poort moet kiezen.
        }
    }
}