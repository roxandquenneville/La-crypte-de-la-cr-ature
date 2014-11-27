using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Args;
using System.Windows.Forms;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Deplacement
    {
        #region attribut
        public virtual int? idDeplacement { get; set; }
        public virtual Pion Pion { get; set;}
        public virtual Pierre Pierre { get; set; }
        public virtual Monstre Monstre { get; set; }
        public virtual Historique Historique { get; set; }
        public virtual Position Depart { get; set; }
        public virtual Position Fin { get; set; }
        #endregion


        /// <summary>
        /// Constructeur de la classe Deplacement pour la bd
        /// </summary>
        public Deplacement()
        {
            Historique= new Historique();
            Depart = new Position();
            Fin = new Position();
        }


        /// <summary>
        /// Constructeur de la classe deplacement
        /// Instancier deux positions et la passer dans le constructeur
        /// </summary>
        /// <param name="posDepart">Position de départ</param>
        /// <param name="posFin">Position de Fin</param>
        public Deplacement(Position posDepart, Position posFin)
        {
            Depart = posDepart;
            Fin = posFin;
            Historique = new Historique();
        }

        #region Pion
        /// <summary>
        /// Confirme le mouvement. 
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public virtual bool Confirmation(Partie partie, List<Deplacement> ListeTmp, int tmpDeplacement,string sens)
        {
            bool Valide = true;
            bool CasePresent;
            string type;
            List<Piece> pTmp = null;
           
           if(Depart== Fin)
           {
               return false;
           }

            //Vérifie la case
            CasePresent = partie.Plateau.ConfirmationCase(Fin);

            //La case n'existe pas ou est externe
            if (CasePresent == false)
            {
                return false;
            }

            pTmp = partie.RetournePiece(Fin);

            // piece et case de sang gérer plus tard
            if (pTmp.Count > 1)
            {
                string type2;
                string tmp;
                int index;

                type = pTmp[0].Get_Type();
                type2 = pTmp[1].Get_Type();

                if(type != ConstanteGlobale.CASEDESANG)
                {
                    tmp=type;
                    index=0;
                }
                else
                {
                    index=1;
                    tmp=type2;
                }

                switch (type)
                {
                    case ConstanteGlobale.PIERRE:
                        Valide = ConfirmationPierre(partie, sens, ListeTmp, pTmp[index]);
                        break;
                    case ConstanteGlobale.MONSTRE:
                        return false;
                    case ConstanteGlobale.PION:
                        if (tmpDeplacement > 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
            }
            else
            {
                //il n'y a pas de piece
                if (pTmp.Count() == 0)
                {
                    return true;
                }
                else
                {
                    type = pTmp[0].Get_Type();
                   
                    switch (type)
                    {
                        case ConstanteGlobale.PIERRE:
                            Valide = ConfirmationPierre(partie, sens, ListeTmp, pTmp[0]);
                            break;
                        case ConstanteGlobale.CASEDESANG:

                                 Position pACote = new Position(Fin.X, Fin.Y);
                                 Position posTmp = new Position(pACote.X, pACote.Y);
                                 RetrieveElementPierre args = new RetrieveElementPierre();

                                 args.CasePresent= CasePresent;
                                 args.pTmp=pTmp;
                                 args.pACote=pACote;
                                 args.posTmp=posTmp;

                                Valide = SurCaseDeSang(partie, sens, ListeTmp, args, tmpDeplacement);
                            break;
                        case ConstanteGlobale.MONSTRE:
                            return false;
                        case ConstanteGlobale.PION:
                            if (tmpDeplacement > 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                    }
                }
            }
            return Valide;
        }



        public virtual bool ConfirmationPierre(Partie partie, string sens, List<Deplacement> ListeTmp, Piece pierre)
        {

            bool CasePresent = false;
            int index = 0;
            Position pACote = new Position(Fin.X, Fin.Y);
            Position posTmp = new Position(pACote.X, pACote.Y);
            List<Piece> pTmp = null;
            Deplacement deplacement = new Deplacement();
            RetrieveElementPierre args = new RetrieveElementPierre();

            deplacement.Depart = Fin;
            deplacement.Pierre = (Pierre)pierre;
            ListeTmp.Add(deplacement);
            index = ListeTmp.Count();


            pACote.ChangePosition(sens);

            // Case extérieur au plateau
            if (pACote == pierre.Position)
            {
                return false;
            }

            //Vérifie la case
            CasePresent = partie.Plateau.ConfirmationCase(pACote);

            //La case n'existe pas ou est externe
            if (CasePresent == false)
            {
                ListeTmp.RemoveAt(index - 1);
                return false;
            }

            pTmp = partie.RetournePiece(pACote);

            // sur une case de sang
            // le pion ne peut pas pousser une pierre sur un autre pierre/pion/monstre
            if (pTmp.Count > 1)
            {
                return false;
            }
            else
            {
                //il n'y a pas de piece
                if (pTmp.Count() == 0)
                {
                    //Déplace la pierre
                    deplacement.Fin = pACote;
                    pierre.Position = pACote;
                    return true;
                }
                // on est sur une case de sang
                else if (pTmp[0].Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    args.CasePresent = CasePresent;
                    args.index = index;
                    args.pACote = pACote;
                    args.posTmp = posTmp;
                    args.pTmp = pTmp;
                    args.deplacement = deplacement;

                    PierreSurCaseDeSang(partie, sens, pierre, ListeTmp, args);
                    return true;
                }
                //pousser une pierre sur une pierre/pion/monstre
                else
                {
                    ListeTmp.RemoveAt(index - 1);
                    return false;
                }
            }

        }

        public virtual void PierreSurCaseDeSang(Partie partie, string sens, Piece pierre, List<Deplacement> ListeTmp, RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            if(args.pACote == args.posTmp)
            {
                pierre.Position.X= args.pACote.X;
                pierre.Position.Y = args.pACote.Y;
                return;
            }

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if (args.CasePresent == false)
            {
                args.deplacement.Fin.X = args.posTmp.X;
                args.deplacement.Fin.Y = args.posTmp.Y;
                pierre.Position.X = args.posTmp.X;
                pierre.Position.Y = args.posTmp.Y;
            }

            args.pTmp = partie.RetournePiece(args.pACote);

            // il y a une piece sur la case de sang
            // la pierre qui a été pousser s'arrête sur la case de sang a cote de la piece
            if ((args.pTmp).Count() > 1)
            {
                args.deplacement.Fin.X = args.posTmp.X;
                args.deplacement.Fin.Y = args.posTmp.Y;
                pierre.Position.X = args.posTmp.X;
                pierre.Position.Y = args.posTmp.Y;
            }
            else
            {
                //tombe sur une case vide
                //arrete sur la case à cote de la case de sang
                if (args.pTmp.Count() == 0)
                {
                    args.deplacement.Fin.X = args.pACote.X;
                    args.deplacement.Fin.Y = args.pACote.Y;
                    pierre.Position.X = args.pACote.X;
                    pierre.Position.Y = args.pACote.Y;
                }
                else if ((args.pTmp[0]).Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    //rappele la fonction
                    PierreSurCaseDeSang(partie, sens, pierre, ListeTmp, args);
                }
                // arrete sur la case de sang
                // pion pousse roche elle arrête sur la case de sang
                // ,car il y a une piece de l'autre côté
                else
                {
                    args.deplacement.Fin.X = args.posTmp.X;
                    args.deplacement.Fin.Y = args.posTmp.Y;
                    pierre.Position.X = args.posTmp.X;
                    pierre.Position.Y = args.posTmp.Y;
                }
            }
        }

        public virtual bool SurCaseDeSang(Partie partie, string sens, List<Deplacement> ListeTmp, RetrieveElementPierre args, int tmpDeplacement)
        {
            bool Valide=true;

            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if (args.CasePresent == false)
            {
                Fin.X = args.posTmp.X;
                Fin.Y = args.posTmp.Y;
                Valide= true;
            }

            args.pTmp = partie.RetournePiece(args.pACote);

            // piece et case de sang
            // pion suit la pierre lorsqu'il pousse
            if ((args.pTmp).Count() > 1)
            {

            }
            else
            {
                // Tombe sur une case vide
                // Arrête sur la case à cote de la case de sang
                if (args.pTmp.Count() == 0)
                {
                    Fin.X = args.pACote.X;
                    Fin.Y = args.pACote.Y;
                    Valide= true;
                }
                else if ((args.pTmp[0]).Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    //rappele la fonction
                    SurCaseDeSang(partie, sens, ListeTmp, args, tmpDeplacement);
                }
                //L'autre coté de la Mare de sang il y a une pièce
                else
                {
                    if (args.pTmp[0].Get_Type() == ConstanteGlobale.PION)
                    {
                        //Il nous reste des point de déplacement et on fini sur un pion
                        if (tmpDeplacement > 1)
                        {
                            Fin.X = args.pACote.X;
                            Fin.Y = args.pACote.Y;
                            Valide= true;
                        }
                        //si on glisse sur une Mare de sang et tombe sur un pion de l'autre côté
                        else
                        {
                            Valide= false;
                        }
                    }
                    //On veut piller sur un monstre
                    else if (args.pTmp[0].Get_Type() == ConstanteGlobale.MONSTRE)
                    {
                        Valide=false;
                    }
                    // un pion glisse sur une case de sang et fini devant la roche
                    else
                    {
                        Valide=ConfirmationPierre(partie,sens,ListeTmp,args.pTmp[0]);
                        //On peut déplacer la pierre
                        if(Valide)
                        {
                            Fin.X = args.pACote.X;
                            Fin.Y = args.pACote.Y;
                        }
                        //On ne peut pas pousser la pierre
                        else
                        {
                            Fin.X = args.posTmp.X;
                            Fin.Y = args.posTmp.Y;
                        }
                    }
                }
            }
            return Valide;
        }
        #endregion

        #region Monstre
        public virtual void MonstreDeplacement(Partie partie, string sens)
        {
            bool casePresent=true;
            List<Piece> pTmp = null;
            string type="";
            Position  posTmp= new Position(Fin.X,Fin.Y);

            Fin.ChangePosition(sens);

            casePresent=partie.Plateau.ConfirmationCase(Fin);

            if ((posTmp.X == Fin.X && posTmp.Y == posTmp.Y) || casePresent == false) 
            {
            #region Magie
             //condition mur

                if(posTmp.X == Fin.X && posTmp.Y == Fin.Y)
                {
                    switch (sens)
                    {
                        case ConstanteGlobale.DESCEND:
                            Fin.Y = 0;
                            break;
                        case ConstanteGlobale.MONTE:
                            Fin.Y = 10;
                            break;
                        case ConstanteGlobale.GAUCHE:
                            Fin.X = 15;
                            break;
                        case ConstanteGlobale.DROITE:
                            Fin.X = 0;
                            break;
                    }
                }
                #endregion
            }
           
                pTmp = partie.RetournePiece(Fin);

                if(pTmp.Count > 1)
                {

                }
                else
                {
                    //il n'y a pas de piece
                    if (pTmp.Count() == 0)
                    {
                        return;
                    }

                   type = pTmp[0].Get_Type();
                    
                    switch (type)
                    {
                        case ConstanteGlobale.CASEDESANG:
                            Position pACote = new Position(Fin.X, Fin.Y);
                            posTmp = new Position(pACote.X, pACote.Y);
                            RetrieveElementPierre args = new RetrieveElementPierre();

                            args.CasePresent= casePresent;
                            args.pTmp=pTmp;
                            args.pACote=pACote;
                            args.posTmp=posTmp;

                            SurCaseDeSang(partie,sens,args);
                            break;
                        case ConstanteGlobale.PIERRE:
                            ConfirmationPierre(partie,sens,pTmp[0]);
                            break;
                        case ConstanteGlobale.PION:
                            ((Pion)pTmp[0]).EstVivant =false;
                            ((Pion)pTmp[0]).EstSortie = true;
                            MessageBox.Show("Le monstre se régale de ton pion");
                            break; 
                    }
                }
                
            
            
        }

        public virtual void ConfirmationPierre(Partie partie, string sens,Piece pierre)
        {

            bool CasePresent = false;
            Position pACote = new Position(Fin.X, Fin.Y);
            Position posTmp = new Position(pACote.X, pACote.Y);
            List<Piece> pTmp = null;
            Deplacement deplacement = new Deplacement();
            RetrieveElementPierre args = new RetrieveElementPierre();

            deplacement.Pierre = (Pierre)pierre;
            deplacement.Depart.X = Fin.X;
            deplacement.Depart.Y = Fin.Y;
            partie.Historique.Deplacement.Add(deplacement);
            int index = partie.Historique.Deplacement.Count;

            pACote.ChangePosition(sens);


            // la case est externe
            if(pACote.X == Fin.X && pACote.Y == Fin.Y)
            {
                ((Pierre)pierre).EstSurPlateau = false;
                partie.Historique.Deplacement.RemoveAt(index-1);
                return;
            }
            //Vérifie la case
            CasePresent = partie.Plateau.ConfirmationCase(pACote);

            //pousse une pierre hors plateau
            if (CasePresent == false)
            {
               ((Pierre)pierre).EstSurPlateau= false;
               partie.Historique.Deplacement.RemoveAt(index-1);
               return;
            }

            pTmp = partie.RetournePiece(pACote);

            // sur une case de sang
            // le pion ne peu pas pousser une pierre sur un autre pierre/pion/monstre
            if (pTmp.Count > 1)
            {
                
            }
            else
            {
                //il n'y a pas de piece
                if (pTmp.Count() == 0)
                {
                    //Déplace la pierre
                    deplacement.Fin.X = pACote.X;
                    deplacement.Fin.Y = pACote.Y;
                    pierre.Position.X = pACote.X;
                    pierre.Position.Y = pACote.Y;
                }
                // on est sur une case de sang
                else if (pTmp[0].Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    args.CasePresent = CasePresent;
                    args.pACote = pACote;
                    args.posTmp = posTmp;
                    args.pTmp = pTmp;
                    args.deplacement = deplacement;

                    PierreSurCaseDeSang(partie, sens, pierre,args);
                }
                //pousser une pierre sur une pierre/pion
                else
                {
                    pierre.Position.X = pACote.X;
                    pierre.Position.Y = pACote.Y;

                    deplacement.Fin.X = pACote.X;
                    deplacement.Fin.Y = pACote.Y;

                    if(pTmp[0].Get_Type() == ConstanteGlobale.PIERRE)
                    {
                        deplacement.ConfirmationPierre(partie, sens, pTmp[0]);
                    }
                    
                }
            }

        }

        public virtual void PierreSurCaseDeSang(Partie partie, string sens, Piece pierre,RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if (args.CasePresent == false)
            {
                args.deplacement.Fin.X = args.posTmp.X;
                args.deplacement.Fin.Y = args.posTmp.Y;
                pierre.Position.X = args.posTmp.X;
                pierre.Position.Y = args.posTmp.Y;
            }

            args.pTmp = partie.RetournePiece(args.pACote);

            // il y a une piece sur la case de sang
            // la pierre qui a été pousser s'arrête sur la case de sang a cote de la piece
            if ((args.pTmp).Count() > 1)
            {
                args.deplacement.Fin.X = args.posTmp.X;
                args.deplacement.Fin.Y = args.posTmp.Y;
                pierre.Position.X = args.posTmp.X;
                pierre.Position.Y = args.posTmp.Y;
            }
            else
            {
                //tombe sur une case vide
                //arrete sur la case à cote de la case de sang
                if (args.pTmp.Count() == 0)
                {
                    args.deplacement.Fin.X = args.pACote.X;
                    args.deplacement.Fin.Y = args.pACote.Y;
                    pierre.Position.X = args.pACote.X;
                    pierre.Position.Y = args.pACote.Y;
                }
                else if ((args.pTmp[0]).Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    //rappele la fonction
                   PierreSurCaseDeSang(partie, sens, pierre,args);
                }
                // arrete sur la case de sang
                // monstre pousse roche elle arrête sur la case de sang
                // ,car il y a une piece de l'autre côté
                else
                {
                    args.deplacement.Fin.X = args.posTmp.X;
                    args.deplacement.Fin.Y = args.posTmp.Y;
                    pierre.Position.X = args.posTmp.X;
                    pierre.Position.Y = args.posTmp.Y;
                }
            }
        }

        public virtual void SurCaseDeSang(Partie partie, string sens, RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if ((args.posTmp.X==args.pACote.X && args.posTmp.Y==args.pACote.Y) || args.CasePresent == false)
            {
                 if(args.posTmp.X==args.pACote.X && args.posTmp.Y==args.pACote.Y)
                {
                    switch (sens)
                    {
                        case ConstanteGlobale.DESCEND:
                            Fin.Y = 0;
                            break;
                        case ConstanteGlobale.MONTE:
                            Fin.Y = 10;
                            break;
                        case ConstanteGlobale.GAUCHE:
                            Fin.X = 15;
                            break;
                        case ConstanteGlobale.DROITE:
                            Fin.X = 0;
                            break;
                    }
                }
            }

            args.pTmp = partie.RetournePiece(args.pACote);

            // piece et case de sang
            // pion suit la pierre lorsqu'il pousse
            if ((args.pTmp).Count() > 1)
            {

            }
            else
            {
                // Tombe sur une case vide
                // Arrête sur la case à cote de la case de sang
                if (args.pTmp.Count() == 0)
                {
                    Fin.X = args.pACote.X;
                    Fin.Y = args.pACote.Y;
                }
                else if ((args.pTmp[0]).Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    //rappele la fonction
                    SurCaseDeSang(partie, sens, args);
                }
                //L'autre coté de la Mare de sang il y a une pièce
                else
                {
                    if (args.pTmp[0].Get_Type() == ConstanteGlobale.PION)
                    {
                        //On mange le pion de l'autre côté
                        Fin.X = args.pACote.X;
                        Fin.Y = args.pACote.Y;

                         ((Pion)args.pTmp[0]).EstVivant =false;
                         ((Pion)args.pTmp[0]).EstSortie = true;

                    }
                    // un pion glisse sur une case de sang et fini devant la roche
                    else
                    {
                        ConfirmationPierre(partie, sens,args.pTmp[0]);
                        Fin.X = args.pACote.X;
                        Fin.Y = args.pACote.Y;
                    }
                }
            }
        }


        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Deplacement d = obj as Deplacement;

            if (d == null)
            {
                return false;
            }

            return this.idDeplacement == d.idDeplacement;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
