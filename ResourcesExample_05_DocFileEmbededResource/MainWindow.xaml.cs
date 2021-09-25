﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ResourcesExample_05_DocFileEmbededResource
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string fileName = currentAssembly.GetName().Name + ".src.testfile.txt";
            Stream stream = currentAssembly.GetManifestResourceStream(fileName);

            string resut = string.Empty;
            using (StreamReader reader= new StreamReader(stream))
            {
                resut = reader.ReadToEnd();
            }
            MessageBox.Show(resut);
        }
    }
}
