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

        public void reset()
        {
            using (progIInoitesegEntities bd = new progIInoitesegEntities())
            {
                ListaAlunos = new ObservableCollection<aluno>(bd.alunos.Include("notas"));
                AlunosView = CollectionViewSource.GetDefaultView(ListaAlunos);
                AlunoCorrente = (aluno)AlunosView.CurrentItem;
                AlunosView.CurrentChanged += AlunosView_CurrentChanged;
            }



        }


        public ViewModel()
        {
            reset();
            
        }

        private void AlunosView_CurrentChanged(object sender, EventArgs e)
        {
            AlunoCorrente = (aluno)AlunosView.CurrentItem;
            
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));

        }

        #endregion

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


        #region navregistos

        public bool cangoFirst()
        {
            return AlunosView.CurrentPosition > 0;
        }

        public bool cangoLast()
        {
            return AlunosView.CurrentPosition < AlunosView.Cast<aluno>().Count() - 1;
        }



        public void goFirst()
        {
            AlunosView.MoveCurrentToFirst();
            
        }

        public void goNext()
        {
            AlunosView.MoveCurrentToNext();
            
        }

        public void goPrevious()
        {
            AlunosView.MoveCurrentToPrevious();
            
        }

        public void goLast()
        {
            AlunosView.MoveCurrentToLast();
            
        }








        #endregion


        #region CRUD
        //Create Retrieve Update Delete

        public void updateAluno(aluno a)
        {
            int aqui = 0;
            using ( progIInoitesegEntities bd = new progIInoitesegEntities())
            {
                
                var este = bd.alunos.Where(x => x.num == a.num).First();
                if (este !=null)
                {
                    aqui = este.num;
                    este.nome = a.nome;
                    este.curso = a.curso;
                    este.fotopath = a.fotopath;
                    bd.SaveChanges();
                }

                reset();
                var novo = ListaAlunos.Where(x => x.num == aqui).First();
                AlunosView.MoveCurrentTo(novo);
                System.Windows.MessageBox.Show("Registo gravado.");

            }

        }


        #endregion

    } // fim classe ViewModel
} //fim do namespace
