using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace istecnotas
{
    public static class Comandos
    {

        public static RoutedUICommand navega1 = new RoutedUICommand("navega1", "navega1", typeof(Comandos));
        public static RoutedUICommand navega2 = new RoutedUICommand("navega2", "navega2", typeof(Comandos));
        public static RoutedUICommand saidaapp = new RoutedUICommand("sair", "sair", typeof(Comandos));


    }
}
