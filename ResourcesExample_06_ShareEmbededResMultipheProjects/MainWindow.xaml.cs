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

namespace ResourcesExample_06_ShareEmbededResMultipheProjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // path common.dll
            //string path = @"C:\Users\HuyNguyen\Desktop\WPF\SourceCode\Resources\ResourcesExample_01_Basic\ResourcesExample_06_ShareEmbededResMultipheProjects\bin\Debug\Common.dll";
            var path = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                , "Common.dll");
            Assembly.LoadFrom(path);
            Assembly commonAssembly = GetAssemblyByName("Common");

            string pathName = commonAssembly.GetName().Name + ".Images.test.jpeg";

            Stream stream = commonAssembly.GetManifestResourceStream(pathName);
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, result.Length);

            img.Source = LoadImage(result);

        }
        public Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return null;
            }
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
