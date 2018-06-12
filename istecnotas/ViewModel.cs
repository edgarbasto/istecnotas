using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace istecnotas
{
    public class ViewModel : INotifyPropertyChanged
    {
        public MainWindow mainwindowproperty { get; set; }

        public ViewModel()
        {
            using (progIInoitesegEntities bd = new  progIInoitesegEntities())
            {
                ListaAlunos = new ObservableCollection<aluno>(bd.alunos.Include("notas"));
                AlunosView = CollectionViewSource.GetDefaultView(ListaAlunos);
                AlunoCorrente = (aluno)AlunosView.CurrentItem;
                AlunosView.CurrentChanged += AlunosView_CurrentChanged;
            }
            
        }

        private void AlunosView_CurrentChanged(object sender, EventArgs e)
        {
            AlunoCorrente = (aluno)AlunosView.CurrentItem;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));

        }

        #region dados

        ObservableCollection<aluno> _listaalunos;
        public ObservableCollection<aluno> ListaAlunos
        {
            get { return _listaalunos; }
            set { _listaalunos = value;
                OnPropertyChanged("ListaAlunos");
            }
        }

        ICollectionView _alunosview;
        public ICollectionView AlunosView
        {
            get { return _alunosview; }
            set { _alunosview = value;
                OnPropertyChanged("AlunosView");
            }
        }

        aluno _alunocorrente;
        public aluno AlunoCorrente
        {
            get { return _alunocorrente; }
            set { _alunocorrente = value;
                OnPropertyChanged("AlunoCorrente");
            }
        }


        #endregion

        #region navpaginas

        public void navega(String pag)
        {
            switch(pag)
            {
                case "Page1":
                    Page1 p1 = new Page1();
                    mainwindowproperty.frame.Navigate(p1);
                    break;
                case "Page2":
                    Page2 p2 = new Page2();
                    mainwindowproperty.frame.Navigate(p2);
                    break;
            }
        }

        public void sair()
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion





    } // fim classe ViewModel
} //fim do namespace
