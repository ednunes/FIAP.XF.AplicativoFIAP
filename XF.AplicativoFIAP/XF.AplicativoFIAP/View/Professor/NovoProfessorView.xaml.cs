using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AplicativoFIAP.Model;

namespace XF.AplicativoFIAP.View.Professor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoProfessorView : ContentPage
    {
        private int professorId = 0;
        public NovoProfessorView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<NovoProfessorView, Model.Professor>(this, "Alteração",
               (navegarParametro, professor) =>
               {
                   BindingContext = professor;
                   professorId = professor.Id;

                   MessagingCenter.Unsubscribe<NovoProfessorView, Model.Professor>(
                       this, "Alteração");
               });
        }

        public async Task OnSalvar(object sender, EventArgs args)
        {
           Model.Professor professor =
           new Model.Professor()
           {
               Nome = txtNome.Text,
               Titulo = txtTitulo.Text,
               Id = professorId
           };
            Limpar();

            await ProfessorRepository.PostProfessorSqlAzureAsync(professor);
            await Navigation.PopAsync();
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }

        private void Limpar()
        {
            txtNome.Text = string.Empty;
            txtTitulo.Text = string.Empty;
        }
    }
}