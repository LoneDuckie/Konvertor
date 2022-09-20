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

namespace Soustavy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool zavora;

        #region Bity
        int prvni = 0b_0000_0000_0000_0001;
        int druhy = 0b_0000_0000_0000_0010;
        int treti = 0b_0000_0000_0000_0100;
        int ctvrty = 0b_0000_0000_0000_1000;
        int paty = 0b_0000_0000_0001_0000;
        int sesty = 0b_0000_0000_0010_0000;
        int sedmy = 0b_0000_0000_0100_0000;
        int osmy = 0b_0000_0000_1000_0000;
        int devaty = 0b_0000_0001_0000_0000;
        int desaty = 0b_0000_0010_0000_0000;
        int jedenacty = 0b_0000_0100_0000_0000;
        int dvanacty = 0b_0000_1000_0000_0000;
        int trinacty = 0b_0001_0000_0000_0000;
        int ctrnacty = 0b_0010_0000_0000_0000;
        int patnacty = 0b_0100_0000_0000_0000;
        int sestnacty = 0b_1000_0000_0000_0000;
        #endregion

        private void Vypis(int hodnota)
        {
            zavora = true;
            try
            {
                #region Decimalka
                DecimalTB.Text = Convert.ToString(hodnota); 
                #endregion

                #region CheckBoxy
                PrvniBit.IsChecked = (hodnota & prvni) != 0;
                DruhyBit.IsChecked = (hodnota & druhy) != 0;
                TretiBit.IsChecked = (hodnota & treti) != 0;
                CtvrtyBit.IsChecked = (hodnota & ctvrty) != 0;
                PatyBit.IsChecked = (hodnota & paty) != 0;
                SestyBit.IsChecked = (hodnota & sesty) != 0;
                SedmyBit.IsChecked = (hodnota & sedmy) != 0;
                OsmyBit.IsChecked = (hodnota & osmy) != 0;
                DevatyBit.IsChecked = (hodnota & devaty) != 0;
                DesatyBit.IsChecked = (hodnota & desaty) != 0;
                JedenactyBit.IsChecked = (hodnota & jedenacty) != 0;
                DvanactyBit.IsChecked = (hodnota & dvanacty) != 0;
                TrinactyBit.IsChecked = (hodnota & trinacty) != 0;
                CtrnactyBit.IsChecked = (hodnota & ctrnacty) != 0;
                PatnactyBit.IsChecked = (hodnota & patnacty) != 0;
                SestnactyBit.IsChecked = (hodnota & sestnacty) != 0;
                #endregion

                #region Hex
                HexTB.Text = Convert.ToString(hodnota, toBase: 16);
                #endregion

                #region Nastavení hodnoty slideru
                Slider.Value = hodnota;
                #endregion
            }
            finally
            {
                zavora = false;
            }

            
        }

        private void bit_Checked(object sender, RoutedEventArgs e)
        {
            if (zavora) return;

            int pomI = 0b_0000_0000_0000_0000;

            if (PrvniBit.IsChecked == true)
                pomI |= prvni;
            if (DruhyBit.IsChecked == true)
                pomI |= druhy;
            if (TretiBit.IsChecked == true)
                pomI |= treti;
            if (CtvrtyBit.IsChecked == true)
                pomI |= ctvrty;
            if (PatyBit.IsChecked == true)
                pomI |= paty;
            if (SestyBit.IsChecked == true)
                pomI |= sesty;
            if (SedmyBit.IsChecked == true)
                pomI |= sedmy;
            if (OsmyBit.IsChecked == true)
                pomI |= osmy;
            if (DevatyBit.IsChecked == true)
                pomI |= devaty;
            if (DesatyBit.IsChecked == true)
                pomI |= desaty;
            if (JedenactyBit.IsChecked == true)
                pomI |= jedenacty;
            if (DvanactyBit.IsChecked == true)
                pomI |= dvanacty;
            if (TrinactyBit.IsChecked == true)
                pomI |= trinacty;
            if (CtrnactyBit.IsChecked == true)
                pomI |= ctrnacty;
            if (PatnactyBit.IsChecked == true)
                pomI |= patnacty;
            if (SestnactyBit.IsChecked == true)
                pomI |= sestnacty;

            Vypis(pomI);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (zavora) return;
            int value = (int)Slider.Value;
            Vypis(value);
        }

        private void HexTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zavora) return;

            if (int.TryParse(HexTB.Text, System.Globalization.NumberStyles.HexNumber, null, out int value))
            {
                if (value > 65535)
                    value = 65535;
                if (value < 1)
                    value = 1;
                Vypis(value);
            }
        }

        private void DecimalTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (zavora) return;

            if(int.TryParse(DecimalTB.Text, out int value))
            {
                if (value > 65535)
                    value = 65535;
                if (value < 1)
                    value = 1;
                Vypis(value);
            }
        }
    }
}
