using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MASTAHU_CALCULATOR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double firstValue = 0.0;
        double answer = 0.0;
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT1.Content : BT1.Content.ToString();
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT2.Content : BT2.Content.ToString();

        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT3.Content : BT3.Content.ToString();

        }

        private void BT4_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT4.Content : BT4.Content.ToString();

        }

        private void BT5_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT5.Content : BT5.Content.ToString();

        }

        private void BT6_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT6.Content : BT6.Content.ToString();

        }

        private void BT7_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT7.Content : BT7.Content.ToString();

        }

        private void BT8_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT8.Content : BT8.Content.ToString();

        }

        private void BT9_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT9.Content : BT9.Content.ToString();

        }

        private void BT00_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT00.Content : BT0.Content.ToString();

        }

        private void BT0_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BT0.Content : BT0.Content.ToString();

        }

        private void BTDOT_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Text = (TBDISPLAY.Text != "0") ? TBDISPLAY.Text + BTDOT.Content : BTDOT.Content.ToString();
            BTDOT.IsEnabled = false;
        }

        private void BTclear_Click(object sender, RoutedEventArgs e)
        {
            TBDISPLAY.Clear();
            TBDISPLAY.Text = "0";
            firstValue = 0.0;
        }
        bool BTAClicked = false;
        bool BTSClicked = false;
        bool BTMClicked = false;
        bool BTDClicked = false;
        private void BTA_Click(object sender, RoutedEventArgs e)
        {
            firstValue = firstValue + double.Parse(TBDISPLAY.Text);
            TBDISPLAY.Clear();
            TBDISPLAY.Text = "0";
            BTAClicked = true;
            BTSClicked = false;
            BTMClicked = false;
            BTDClicked = false;
         }

        private void BTE_Click(object sender, RoutedEventArgs e)
        {
            if (BTAClicked == true)
            {
                answer = firstValue + double.Parse(TBDISPLAY.Text);
            }
            else if
                (BTSClicked == true)
            {
                answer = firstValue - double.Parse(TBDISPLAY.Text);
            }
            else if
                (BTMClicked == true)
            {
                answer = firstValue * double.Parse(TBDISPLAY.Text);
            }
            else if
                (BTDClicked == true)
            {
                answer = firstValue / double.Parse(TBDISPLAY.Text);
            }
            TBDISPLAY.Text = answer.ToString();
            firstValue = 0.0;
        }

        private void BTS_Click(object sender, RoutedEventArgs e)
        {
            firstValue = firstValue + double.Parse(TBDISPLAY.Text);
            TBDISPLAY.Clear();
            TBDISPLAY.Text = "0";
            BTSClicked = true;
            BTAClicked = false;
            BTDClicked = false;
            BTMClicked = false;
        }

        private void BTD_Click(object sender, RoutedEventArgs e)
        {
            firstValue = firstValue + double.Parse(TBDISPLAY.Text);
            TBDISPLAY.Clear();
            TBDISPLAY.Text = "0";
            BTDClicked = true;
            BTAClicked = false;
            BTSClicked = false;
            BTMClicked = false;
        }

        private void BTM_Click(object sender, RoutedEventArgs e)
        {
            firstValue = firstValue + double.Parse(TBDISPLAY.Text);
            TBDISPLAY.Clear();
            TBDISPLAY.Text = "0";
            BTMClicked = true;
            BTAClicked = false;
            BTDClicked = false;
            BTSClicked = false;
        }

        private void TBDISPLAY_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
