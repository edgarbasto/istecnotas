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

namespace istecnotas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel vmproperty { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            vmproperty = (ViewModel)Resources["vm"];
            vmproperty.mainwindowproperty = this;
            ligabotoes();

        }

        public void ligabotoes()
        {
            CommandBindings.Add(new CommandBinding(
                Comandos.navega1,
                (sender, e) => vmproperty.navega("Page1"),
                (sender, e) => e.CanExecute = true
                ));

            CommandBindings.Add(new CommandBinding(
                Comandos.navega2,
                (sender, e) => vmproperty.navega("Page2"),
                (sender, e) => e.CanExecute = true
                ));

            CommandBindings.Add(new CommandBinding(
                Comandos.saidaapp,
                (sender, e) => vmproperty.sair(),
                (sender, e) => e.CanExecute = true
                ));

        }



        // Tinhamos um Click="MenuItem_Click" no elemento Página 2 do XAML
        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    Page2 pag2 = new Page2();
        //    this.frame.Navigate(pag2);
        //}


    }
}
