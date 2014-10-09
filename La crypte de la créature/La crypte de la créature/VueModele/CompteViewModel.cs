﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit;
using Cstj.MvvmToolkit.Services;
using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Services.Definitions;

namespace La_crypte_de_la_creature.UI.ViewModel
{
    public class CompteViewModel : BaseViewModel
    {
        
        #region Service
        private ICompteService _proprieteCompte;
        #endregion

        public RetrieveCompteArgs RetrieveArgs { get;set;}

        public CompteViewModel()
        {
            Comptes = new ObservableCollection<Compte>(ServiceFactory.Instance.GetService<ICompteService>().RetrieveAll());
            Compte = new Compte();
        }
       
        #region Bindable
        private Compte _compte;

        public Compte Compte
        {
            get
            {
                return _compte;
            }

            set
            {
                if (_compte == value)
                {
                    return;
                }
                _compte = value;
            }
             
        }

        private ObservableCollection<Compte> _comptes = new ObservableCollection<Compte>();

        public ObservableCollection<Compte> Comptes
        {
            get
            {
                return _comptes;
            }

            set
            {
                if (_comptes == value)
                {
                    return;
                }

                _comptes = value;
            }
        }

        #endregion

        #region Command
        
        public void SauvegarderCommand()
        {
           _proprieteCompte.Update(Compte);
        }

        #endregion
    }
}
