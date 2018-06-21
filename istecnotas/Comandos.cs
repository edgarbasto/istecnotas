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

        public static RoutedUICommand vaiPrimeiro = new RoutedUICommand("vaiPrimeiro", "vaiPrimeiro", typeof(Comandos));
        public static RoutedUICommand vaiProximo = new RoutedUICommand("vaiProximo", "vaiProximo", typeof(Comandos));
        public static RoutedUICommand vaiAnterior = new RoutedUICommand("vaiAnterior", "vaiAnterior", typeof(Comandos));
        public static RoutedUICommand vaiUltimo = new RoutedUICommand("vaiUltimo", "vaiUltimo", typeof(Comandos));

        public static RoutedUICommand atualizaAluno = new RoutedUICommand("atualizaAluno", "atualizaAluno", typeof(Comandos));


    }
}
