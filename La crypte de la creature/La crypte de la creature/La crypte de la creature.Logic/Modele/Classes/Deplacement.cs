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
       /// Confirme le mouvement du pion. 
       /// <param name="partie">La partie en cours</param>
       /// <param name="ListeTmp">Liste de déplacement effectuer par le pion</param>
       /// <param name="tmpDeplacement">Nombre de point de déplacement disponible du pion</param>
       /// <param name="sens">Direction</param>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public virtual bool Confirmation(Partie partie, List<Deplacement> ListeTmp, int tmpDeplacement,string sens)
        {
            bool Valide = true;
            bool CasePresent;
            string type;
            List<Piece> pTmp = null;

            //Le pion essais d'acceder à une case hors plateau
           if(Depart == Fin)
           {
               return false;
           }

            //Vérifie si case est externe
            CasePresent = partie.Plateau.ConfirmationCase(Fin);

            //La case est externe
            if (CasePresent == false)
            {
                return false;
            }
            //Retourne une piece s'il y en a une a cette position
            pTmp = partie.RetournePiece(Fin);
           
            // Deux pièces sont sur cette case soit une case de sang et une pierre ou un pion ou un monstre 
            if (pTmp.Count > 1)
            {
                string type2;
                int index;

                type = pTmp[0].Get_Type();
                type2 = pTmp[1].Get_Type();

                // Trouve la pièce qui n'est pas une case de sang
                if(type != ConstanteGlobale.CASEDESANG)
                {
                    index=0;
                }
                else
                {
                    index=1;
                }

                //  Effectue les confirmations pour la pièce correspondante
                switch (pTmp[index].Get_Type())
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
                    type = pTmp.First().Get_Type();

                    //  Effectue les confirmations pour la pièce correspondante
                    switch (type)
                    {
                        case ConstanteGlobale.PIERRE:
                            Valide = ConfirmationPierre(partie, sens, ListeTmp, pTmp.First());
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


        /// <summary>
        /// Vérifie que la pierre peut être déplacer
        /// </summary>
        /// <param name="partie">La partie actuelle</param>
        /// <param name="sens">Direction</param>
        /// <param name="ListeTmp">Liste de déplacement effectuer par le pion</param>
        /// <param name="pierre">La piece qui est à vérifier (Piece)</param>
        /// <returns>Retourne vrai si le mouvement peut être effectuer sinon return faux</returns>
        public virtual bool ConfirmationPierre(Partie partie, string sens, List<Deplacement> ListeTmp, Piece pierre)
        {

            bool CasePresent = false;
            int index = 0;
            Position pACote = new Position(Fin.X, Fin.Y);
            Position posTmp = new Position(pACote.X, pACote.Y);
            List<Piece> pTmp = null;
            Deplacement deplacement = new Deplacement();
            RetrieveElementPierre args = new RetrieveElementPierre();

            deplacement.Depart.X = Fin.X;
            deplacement.Depart.Y = Fin.Y;
            //Pour la base de donnée
            deplacement.Pierre = (Pierre)pierre;

            ListeTmp.Add(deplacement);
            index = ListeTmp.Count();


            pACote.ChangePosition(sens);

            // Case extérieur au plateau
            if (pACote == pierre.Position)
            {
                return false;
            }

            //Vérifie la case si la est externe
            CasePresent = partie.Plateau.ConfirmationCase(pACote);

            //La case est externe
            if (CasePresent == false)
            {
                ListeTmp.RemoveAt(index - 1);
                return false;
            }

            //Vérifie à cette position si il y a une pièce
            pTmp = partie.RetournePiece(pACote);

            // sur une case de sang
            // le pion ne peut pas pousser une pierre sur un autre pierre/pion/monstre
            if (pTmp.Count > 1)
            {
                ListeTmp.RemoveAt(index - 1);
                return false;
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

        /// <summary>
        /// Vérifie que la pierre peut être pousser sur une case de sang
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        /// <param name="ListeTmp">Liste de déplacement temporaire</param>
        /// <param name="pierre">La piece qui est à vérifier</param>
        /// <param name="args">Liste des argument nécessaire à la fonction</param>
        public virtual void PierreSurCaseDeSang(Partie partie, string sens, Piece pierre, List<Deplacement> ListeTmp, RetrieveElementPierre args)
        {
            //Position précédente
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //La case sur laquelle on essais de pousser une pierre est une case extérieur
            if(args.pACote == args.posTmp)
            {
                pierre.Position.X= args.pACote.X;
                pierre.Position.Y = args.pACote.Y;
                return;
            }

            //Vérifie si la case est externe
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case  est externe
            //arrête sur la case de sang
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


        /// <summary>
        /// Vérifie que le pion peut se déplacer sur la case de sang
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        /// <param name="ListeTmp">Liste de déplacement temporaire</param>
        /// <param name="args">Liste des argument nécessaire à la fonction</param>
        /// <param name="tmpDeplacement">Nombre de déplacement que le pion a de disponible</param>
        /// <returns>Retourne true si le mouvement peut être effectuer</returns>
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
            // En cours...
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
                    //On veut piler sur un monstre
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
        /// <summary>
        /// Vérifie les déplacements du monstre
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        public virtual void MonstreDeplacement(Partie partie, string sens)
        {
            bool casePresent=true;
            List<Piece> pTmp = null;
            string type="";
            Position  posTmp= new Position(Fin.X,Fin.Y);

            Fin.ChangePosition(sens);

            casePresent=partie.Plateau.ConfirmationCase(Fin);

            //Vérifie si le monstre essais de traverser un mur
            if ((posTmp.X == Fin.X && posTmp.Y == Fin.Y) || casePresent == false) 
            {
            #region Magie
             //condition mur
             //Le monstre prend un passage secret
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
                //Pour valider que le monstre ne s'arrête pas sur le gazon
                MonstreCaseExterne(sens, Fin, partie.Plateau);
                #endregion
            }
           
            pTmp = partie.RetournePiece(Fin);

            //Si il y a plus d'une pièce
            // case de sang + pion ou case de sang + pierre
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

                        MonstreSurCaseDeSang(partie, sens, args);
                        break;
                    case ConstanteGlobale.PIERRE:
                        MonstreConfirmationPierre(partie, sens, pTmp[0]);
                        break;
                    case ConstanteGlobale.PION:
                        ((Pion)pTmp[0]).EstVivant =false;
                        ((Pion)pTmp[0]).EstSortie = true;
                        MessageBox.Show("Le monstre se régale de ton pion");
                        break; 
                }
            }           
        }

        /// <summary>
        ///  Effectue le déplacement de la pierre pousser par le monstre
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        /// <param name="pierre">La piece qui est à vérifier</param>
        public virtual void MonstreConfirmationPierre(Partie partie, string sens,Piece pierre)
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

            // Sur une case de sang
            // Le monstre pousse la piece
            // En cours
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

                    MonstrePoussePierreSurCaseDeSang(partie, sens, pierre, args);
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
                        deplacement.MonstreConfirmationPierre(partie, sens, pTmp[0]);
                    }
                    
                }
            }

        }
        /// <summary>
        ///  Le monstre pousse une pierre sur une case de sang
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        /// <param name="pierre">La piece qui est à vérifier</param>
        /// <param name="args">Liste des argument nécessaire à la fonction</param>
        public virtual void MonstrePoussePierreSurCaseDeSang(Partie partie, string sens, Piece pierre,RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case  est externe
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
                    MonstrePoussePierreSurCaseDeSang(partie, sens, pierre, args);
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

        /// <summary>
        /// Le monstre se déplace sur une case de sang
        /// </summary>
        /// <param name="partie">La partie</param>
        /// <param name="sens">Direction</param>
        /// <param name="args">Liste des argument nécessaire à la fonction</param>
        public virtual void MonstreSurCaseDeSang(Partie partie, string sens, RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote.ChangePosition(sens);

            //Le monstre glisse sur la case de sang et prend un passage secret
            // En cours
            if (args.pACote == args.posTmp)
            {
                
            }

            //Vérifie la case
            args.CasePresent = partie.Plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if ((args.posTmp.X==args.pACote.X && args.posTmp.Y==args.pACote.Y) || args.CasePresent == false)
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

            args.pTmp = partie.RetournePiece(args.pACote);

            // piece et case de sang
            // Monstre suit la pierre lorsqu'il pousse
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
                    MonstreSurCaseDeSang(partie, sens, args);
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
                        MonstreConfirmationPierre(partie, sens,args.pTmp[0]);
                        Fin.X = args.pACote.X;
                        Fin.Y = args.pACote.Y;
                    }
                }
            }
        }

        /// <summary>
        /// Vérifie que le monstre ne fini pas sur le gazon
        /// </summary>
        /// <param name="sens">Direction</param>
        /// <param name="posTest">Position à vérifier</param>
        /// <param name="plateau">Plateau</param>
        public virtual void MonstreCaseExterne(String sens,Position posTest,Plateau plateau)
        {
            while(!(plateau.ConfirmationCase(posTest)))
            {
                posTest.ChangePosition(sens);
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
