﻿using System;
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

namespace prak1
{
    /// <summary>
    /// Логика взаимодействия для Main2.xaml
    /// </summary>
    public partial class Main2 : Page
    {
        public Main2()
        {
            InitializeComponent();
        }
        private void BakeryClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page4();
        }
        private void ProductsClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page5();
        }
        private void DeliveryClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page6();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void NeskolkoClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page8();
        }
    }
}
