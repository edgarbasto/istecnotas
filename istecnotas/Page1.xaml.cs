using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace istecnotas
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public MainWindow main { get; set; }

        public Page1()
        {
            InitializeComponent();
            main = (MainWindow)Application.Current.MainWindow;
            this.DataContext = main.vmproperty;
            ligabutones();
        } //construtor

        public void ligabutones()
        {
            CommandBindings.Add(new CommandBinding(
                Comandos.vaiPrimeiro,
                (sender, e) => main.vmproperty.goFirst(),
                (sender, e) => e.CanExecute = main.vmproperty.cangoFirst()
                ));
            CommandBindings.Add(new CommandBinding(
                Comandos.vaiProximo,
                (sender, e) => main.vmproperty.goNext(),
                (sender, e) => e.CanExecute = main.vmproperty.cangoLast()
                ));

            CommandBindings.Add(new CommandBinding(
                Comandos.vaiAnterior,
                (sender, e) => main.vmproperty.goPrevious(),
                (sender, e) => e.CanExecute = main.vmproperty.cangoFirst()
                ));

            CommandBindings.Add(new CommandBinding(
                Comandos.vaiUltimo,
                (sender, e) => main.vmproperty.goLast(),
                (sender, e) => e.CanExecute = main.vmproperty.cangoLast()
                ));

            CommandBindings.Add(new CommandBinding(
                Comandos.atualizaAluno,
                (sender, e) => main.vmproperty.updateAluno(main.vmproperty.AlunoCorrente),
                (sender, e) => e.CanExecute = true
                ));


        }





    } //fim page


    public class convertecaminhotoimage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage foto = null;
            string caminho = Environment.CurrentDirectory;
            caminho = caminho.Substring(0, caminho.IndexOf("bin")) + "imagens";

            if (value == null || String.IsNullOrEmpty(value.ToString()))
            {
                caminho = caminho + "\\nofoto.png";
            } else caminho = value.ToString();

            foto = new BitmapImage();
            foto.BeginInit();
            foto.DecodePixelWidth = 100;
            foto.CacheOption = BitmapCacheOption.OnLoad;
            foto.CreateOptions = BitmapCreateOptions.DelayCreation;
            foto.UriSource = new Uri(caminho, UriKind.Absolute);
            foto.EndInit();

            return foto;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


} //fim namespace
