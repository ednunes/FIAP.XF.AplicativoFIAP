using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AplicativoFIAP.ViewModel;

namespace XF.AplicativoFIAP.View.Professor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProfessoresView : ContentPage
    {
        ProfessorViewModel vmProfessor;
        public ListaProfessoresView()
        {
            vmProfessor = new ProfessorViewModel();
            BindingContext = vmProfessor;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmProfessor = new ProfessorViewModel();
            BindingContext = vmProfessor;
            base.OnAppearing();
        }

        private void OnNovo(object sender, EventArgs args)
        {
           Navigation.PushAsync(new
           NovoProfessorView());
        }

        private void OnProfessorTapped(object sender, ItemTappedEventArgs args)
        {
            var professorSelecionado = args.Item as Model.Professor;
            MessagingCenter.Send<NovoProfessorView, Model.Professor>(new NovoProfessorView(), "Alteração", professorSelecionado);
        }
    }
}