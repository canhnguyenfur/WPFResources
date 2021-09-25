
using System;
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

namespace ResourcesExample_07_LoadDllFromEmbededResource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            string fileName = assembly.GetName().Name + ".Resources.Common.dll";

            Stream stream = assembly.GetManifestResourceStream(fileName);
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, result.Length);

            var loaded = Assembly.Load(result);
        }
    }
}
