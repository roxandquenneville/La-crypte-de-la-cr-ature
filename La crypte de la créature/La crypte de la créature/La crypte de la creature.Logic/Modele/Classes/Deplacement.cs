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
        /// La fonction est Private ,car elle est appeler seulement dans la classe déplacement par une autre fonction
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public virtual bool Confirmation(Plateau plateau, ref List<Deplacement> ListeTmp)
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
                if (pTmp[0] == null)
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
                            Valide = ConfirmationPierre(plateau, sens, ref ListeTmp, pTmp[0]);
                            break;
                        case "CaseDeSang":
                            Console.WriteLine("Case 2");
                            break;
                        case "Monstre":
                            return false;

                    }
                }
            }
            return Valide;
        }



        public bool ConfirmationPierre(Plateau plateau, string sens, ref List<Deplacement> ListeTmp, Piece pierre)
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


            pACote = ChangePosition(sens, pACote);
            //Vérifie la case
            CasePresent = plateau.ConfirmationCase(pACote);

            //La case n'existe pas ou est externe
            if (CasePresent == false)
            {
                ListeTmp.RemoveAt(index - 1);
                return false;
            }

            pTmp = plateau.RetournePiece(pACote);

            if (pTmp.Count > 1)
            {
                return false;

            }
            else
            {

                //il n'y a pas de piece
                if (pTmp[0] == null)
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

                    PierreSurCaseDeSang(plateau, sens, pierre, ref ListeTmp, ref args);
                    return true;
                }
                else
                {
                    ListeTmp.RemoveAt(index - 1);
                    return false;
                }
            }

        }

        public void PierreSurCaseDeSang(Plateau plateau, string sens, Piece pierre, ref List<Deplacement> ListeTmp, ref RetrieveElementPierre args)
        {
            args.posTmp.X = args.pACote.X;
            args.posTmp.Y = args.pACote.Y;

            //change la position de la case à côté
            args.pACote = ChangePosition(sens, args.pACote);

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
            if ((args.pTmp).Count() > 1)
            {

            }
            else
            {
                //tombe sur une case vide
                //arrete sur la case à cote de la case de sang
                if (args.pTmp[0] == null)
                {
                    args.deplacement.Fin = args.pACote;
                    pierre.Position.X = args.pACote.X;
                    pierre.Position.Y = args.pACote.Y;
                }
                else if ((args.pTmp[0]).Get_Type() == "CaseDeSang")
                {
                    //rappele la fonction
                    PierreSurCaseDeSang(plateau, sens, pierre, ref ListeTmp, ref args);
                }
                //arrete sur la case de sang
                else
                {
                    args.deplacement.Fin = args.posTmp;
                    pierre.Position = args.posTmp;
                }
            }
        }

        /// <summary>
        /// Permet de changer la position diriger selon le sens
        /// </summary>
        /// <param name="sens">sens droite gauche monte descent</param>
        /// <param name="pACote">Position à modifier</param>
        /// <returns>Retourne la nouvelle position</returns>
        public Position ChangePosition(string sens, Position pACote)
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
            return pACote;
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
