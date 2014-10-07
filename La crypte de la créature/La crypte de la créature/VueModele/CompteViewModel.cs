using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit;
using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Services.Definitions;

namespace La_crypte_de_la_creature.UI.ViewModel
{
    public class CompteViewModel : BaseViewModel
    {
        
        #region Service
        private ICompteService _proprieteCompte;
        #endregion

        public RetrieveCompteArgs RetrieveArgs { get;set;}

        
       
    }
}
