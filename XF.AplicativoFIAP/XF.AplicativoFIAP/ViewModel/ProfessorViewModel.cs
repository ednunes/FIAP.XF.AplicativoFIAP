using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.AplicativoFIAP.Model;

namespace XF.AplicativoFIAP.ViewModel
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel() { }

        #region Propriedades

        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Professor> Professores
        {
            get
            {
                return ProfessorRepository.GetProfessoresSqlAzureAsync().Result;
            }
        }
        #endregion
    }
}
