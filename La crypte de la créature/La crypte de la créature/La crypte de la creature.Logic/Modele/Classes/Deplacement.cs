using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Deplacement
    {
        #region attribut
        public virtual int? idDeplacement { get; set; }
        public virtual Partie Partie { get; set; }
        public virtual Piece Piece { get; set; }
        public virtual Historique Historique { get; set; }
        public virtual Position Depart { get; set; }
        public virtual Position Fin { get; set; }
        #endregion


        /// <summary>
        /// Constructeur de la classe Deplacement pour la bd
        /// </summary>
        public Deplacement()
        {
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
        }

        /// <summary>
        /// Confirme le mouvement. 
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public virtual bool Confirmation(Plateau plateau, List<Deplacement> ListeTmp, int tmpDeplacement)
        {
            bool Valide = true;
            bool CasePresent;
            string type;
            List<Piece> pTmp = null;

            //Vérifie la case
            CasePresent = plateau.ConfirmationCase(Fin);

            //La case n'existe pas ou est externe
            if (CasePresent == false)
            {
                return false;
            }

            pTmp = plateau.RetournePiece(Fin);

            // pierre et case de sang gérer plus tard
            if (pTmp.Count > 1)
            {

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
                    string sens = "";

                    if ((Depart.X - Fin.X) > 0)
                    {
                        sens = "gauche";
                    }
                    if ((Depart.X - Fin.X) < 0)
                    {
                        sens = "droite";
                    }
                    if ((Depart.Y - Fin.Y) > 0)
                    {
                        sens = "monte";
                    }
                    if ((Depart.Y - Fin.Y) < 0)
                    {
                        sens = "descend";
                    }

                    switch (type)
                    {
                        case "Pierre":
                            Valide = ConfirmationPierre(plateau, sens, ListeTmp, pTmp[0]);
                            break;
                        case "CaseDeSang":
                            SurCaseDeSang(plateau, sens, ListeTmp, false);
                            break;
                        case "Monstre":
                            return false;
                        case "Pion":
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



        public virtual bool ConfirmationPierre(Plateau plateau, string sens, List<Deplacement> ListeTmp, Piece pierre)
        {

            bool CasePresent = false;
            int index = 0;
            Position pACote = new Position(Fin.X, Fin.Y);
            Position posTmp = new Position(pACote.X, pACote.Y);
            List<Piece> pTmp = null;
            Deplacement deplacement = new Deplacement();
            RetrieveElementPierre args = new RetrieveElementPierre();

            deplacement.Depart = Fin;
            ListeTmp.Add(deplacement);
            index = ListeTmp.Count();


            ChangePosition(sens, pACote);
            //Vérifie la case
            CasePresent = plateau.ConfirmationCase(pACote);

            //La case n'existe pas ou est externe
            if (CasePresent == false)
            {
                ListeTmp.RemoveAt(index - 1);
                return false;
            }

            pTmp = plateau.RetournePiece(pACote);

            // sur une case de sang
            // le pion ne peu pas pousser une pierre sur un autre pierre/pion/monstre
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
                else if (pTmp[0].Get_Type() == "CaseDeSang")
                {
                    args.CasePresent = CasePresent;
                    args.index = index;
                    args.pACote = pACote;
                    args.posTmp = posTmp;
                    args.pTmp = pTmp;
                    args.deplacement = deplacement;

                    PierreSurCaseDeSang(plateau, sens, pierre, ListeTmp, args);
                    return true;
                }
                else
                {
                    ListeTmp.RemoveAt(index - 1);
                    return false;
                }
            }

        }

        public virtual void PierreSurCaseDeSang(Plateau plateau, string sens, Piece pierre, List<Deplacement> ListeTmp, RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            ChangePosition(sens, args.pACote);

            //Vérifie la case
            args.CasePresent = plateau.ConfirmationCase(args.pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if (args.CasePresent == false)
            {
                args.deplacement.Fin = args.posTmp;
                pierre.Position = args.posTmp;
            }

            args.pTmp = plateau.RetournePiece(args.pACote);

            // pierre et case de sang
            // pion suit la pierre lorsqu'il pousse
            if ((args.pTmp).Count() > 1)
            {

            }
            else
            {
                //tombe sur une case vide
                //arrete sur la case à cote de la case de sang
                if (args.pTmp.Count() == 0)
                {
                    args.deplacement.Fin = args.pACote;
                    pierre.Position.X = args.pACote.X;
                    pierre.Position.Y = args.pACote.Y;
                }
                else if ((args.pTmp[0]).Get_Type() == "CaseDeSang")
                {
                    //rappele la fonction
                    PierreSurCaseDeSang(plateau, sens, pierre, ListeTmp, args);
                }
                // arrete sur la case de sang
                // pion sur un autre pion 
                // pion pousse roche
                else
                {
                    args.deplacement.Fin = args.posTmp;
                    pierre.Position = args.posTmp;
                }
            }
        }

        public virtual void SurCaseDeSang(Plateau plateau, string sens, List<Deplacement> ListeTmp, bool recursive)
        {
            if (recursive == false)
            {
                Position pACote = new Position(Fin.X, Fin.Y);
                Position posTmp = new Position(pACote.X, pACote.Y);
                bool CasePresent = true;
                List<Piece> pTmp = null;
            }

            posTmp.X = pACote.X;
            posTmp.Y = pACote.Y;

            //change la position de la case à côté
            ChangePosition(sens, pACote);

            //Vérifie la case
            CasePresent = plateau.ConfirmationCase(pACote);

            //La case n'existe pas ou est externe
            //arrete sur la case de sang
            if (CasePresent == false)
            {
                Fin = posTmp;
            }

            pTmp = plateau.RetournePiece(pACote);

            // pierre et case de sang
            // pion suit la pierre lorsqu'il pousse
            if ((pTmp).Count() > 1)
            {

            }
            else
            {
                // Tombe sur une case vide
                // Arrête sur la case à cote de la case de sang
                if (pTmp.Count() == 0)
                {
                    Fin.X = pACote.X;
                    Fin.Y = pACote.Y;
                }
                else if ((pTmp[0]).Get_Type() == "CaseDeSang")
                {
                    //rappele la fonction
                    SurCaseDeSang(plateau, sens, ListeTmp, true);
                }
                // arrete sur la case de sang
                // pion sur un autre pion 
                // pion pousse roche
                else
                {

                }
            }
        }

        /// <summary>
        /// Permet de changer la position diriger selon le sens
        /// </summary>
        /// <param name="sens">sens droite gauche monte descent</param>
        /// <param name="pACote">Position à modifier</param>
        /// <returns>Retourne la nouvelle position</returns>
        public virtual void ChangePosition(string sens, Position pACote)
        {
            string test = sens;
            switch (test)
            {
                case "gauche":
                    pACote.X = pACote.X - 1;
                    break;
                case "droite":
                    pACote.X = pACote.X + 1;
                    break;
                case "monte":
                    pACote.Y = pACote.Y - 1;
                    break;
                case "descend":
                    pACote.Y = pACote.Y + 1;
                    break;
            }
        }

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
