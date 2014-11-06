using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Monstre : Piece
    {
        #region attribut
        private int orientation;

        public virtual int? idMonstre { get { return base.idPiece; } set { base.idPiece = value; } }

        public virtual int Orientation
        {
            get { return orientation; }
            set 
            {
                if (value > -1 && value < 4)
                {
                    orientation = value;
                }
            }

        }
        #endregion

        /// <summary>
        /// constructeur de la classe Pion
        /// </summary>
        public Monstre():base()
        {
        }


        /// <summary>
        /// Constructeur de la classe monstre
        /// </summary>
        /// <param name="posXY">Position du monstre</param>
        /// <param name="Sens">LE sens du monstre 0 = gauche 1 = haut 2 = droite 3 = bas</param>
        public Monstre(Position posXY, int Sens): base(posXY)
        {
            Orientation = Sens;
            DetermineImage();
        }

        /// <summary>
        /// Determine quel monstre sera prit
        /// </summary>
        /// <returns>retourne le nom du monstre utilisé</returns>
        public virtual string DeterminerMonstre()
        {
            string nom="";
            
            return nom;
        }



        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "Monstre"</returns>
        public override string Get_Type() { return ConstanteGlobale.MONSTRE ; }

        /// <summary>
        /// Determine l'image du monstre
        /// </summary>
        public override void DetermineImage()
        {
            Url = "pack://application:,,,/Images/Alain2.png";
        }


        public virtual string VisionMonstre(string sens, Plateau plateau)
        {
            //     - - - -  -    - - - - 
            //     - - - -  -    - - - -
            //     - - - - M(m) - - - -
            //     - - - -  -    - - - - 
            //     - - - -  -    - - - -

            List<Piece> pTmp = new List<Piece>();
            List<int> iTmp = new List<int>();



            switch (sens)
            {
                case ConstanteGlobale.MONTE:
                    pTmp.Add(MonstreRegarde(plateau, ConstanteGlobale.GAUCHE));
                    iTmp.Add(CompteDistance(pTmp[0]));
                    pTmp.Add(MonstreRegarde(plateau, ConstanteGlobale.DROITE));
                    iTmp.Add(CompteDistance(pTmp[1]));
                    pTmp.Add(MonstreRegarde(plateau, ConstanteGlobale.MONTE));
                    iTmp.Add(CompteDistance( pTmp[2]));

                    if (iTmp[0] < iTmp[1])
                    {
                        if (iTmp[0] < iTmp[2])
                        {
                            return ConstanteGlobale.GAUCHE;
                        }
                        else if (iTmp[0] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.MONTE;
                        }
                    }
                    else if (iTmp[0] > iTmp[1])
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return ConstanteGlobale.DROITE;
                        }
                        else if (iTmp[1] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.MONTE;
                        }
                    }
                    else
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.MONTE;
                        }
                    }

                case ConstanteGlobale.DESCEND:
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.GAUCHE));
                    iTmp.Add(CompteDistance(pTmp[0]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.DROITE));
                    iTmp.Add(CompteDistance(pTmp[1]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.DESCEND));
                    iTmp.Add(CompteDistance(pTmp[2]));

                    if (iTmp[0] < iTmp[1])
                    {
                        if (iTmp[0] < iTmp[2])
                        {
                            return ConstanteGlobale.GAUCHE;
                        }
                        else if (iTmp[0] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else if (iTmp[0] > iTmp[1])
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return ConstanteGlobale.DROITE;
                        }
                        else if (iTmp[1] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.MONTE;
                        }
                    }


                case ConstanteGlobale.GAUCHE:
                    pTmp.Add(MonstreRegarde(plateau, ConstanteGlobale.GAUCHE));
                    iTmp.Add(CompteDistance(pTmp[0]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.MONTE));
                    iTmp.Add(CompteDistance(pTmp[1]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.DESCEND));
                    iTmp.Add(CompteDistance(pTmp[2]));

                    if (iTmp[0] < iTmp[1])
                    {
                        if (iTmp[0] < iTmp[2])
                        {
                            return ConstanteGlobale.GAUCHE;
                        }
                        else if (iTmp[0] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else if (iTmp[0] > iTmp[1])
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return ConstanteGlobale.MONTE;
                        }
                        else if (iTmp[1] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }

                case ConstanteGlobale.DROITE: 
                    pTmp.Add(MonstreRegarde(plateau, ConstanteGlobale.DROITE));
                    iTmp.Add(CompteDistance( pTmp[0]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.MONTE));
                    iTmp.Add(CompteDistance(pTmp[1]));
                    pTmp.Add(MonstreRegarde(plateau,ConstanteGlobale.DESCEND));
                    iTmp.Add(CompteDistance(pTmp[2]));

                    if(iTmp[0] == -1)
                    {
                        iTmp[0] = 5000;    
                    }
                    if (iTmp[1] == -1)
                    {
                        iTmp[1] = 5000;
                    }
                    if (iTmp[2] == -1)
                    {
                        iTmp[2] = 5000;
                    }

                    if(iTmp.Min() == 5000)
                    {
                        return sens;
                    }

                    if (iTmp[0] < iTmp[1])
                    {
                        if (iTmp[0] < iTmp[2])
                        {
                            return ConstanteGlobale.DROITE;
                        }
                        else if (iTmp[0] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else if (iTmp[0] > iTmp[1])
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return ConstanteGlobale.MONTE;
                        }
                        else if (iTmp[1] == iTmp[2])
                        {
                            return sens;
                        }
                        else
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                    }
                    else
                    {
                        if (iTmp[1] < iTmp[2])
                        {
                            return sens;
                        }
                        else if (iTmp[1] > iTmp[2])
                        {
                            return ConstanteGlobale.DESCEND;
                        }
                        else
                        {
                            return sens;
                        }
                    }
            }
            return sens;
        }

        public virtual Piece MonstreRegarde(Plateau plateau, string sens)
        {
            List<Piece> pTmp = null;
            Piece pionTmp = null;
            Position tmp = new Position();
            tmp.X = Position.X;
            tmp.Y = Position.Y;

            // Regarde les cases à gauche
            // tmp.x <15
            // tmp.y > 0
            // tmp.y < 11
            
            switch (sens)
            {
                case ConstanteGlobale.GAUCHE:
                    while (tmp.X > 0)
                    {  
                    
                      tmp.ChangePosition(ConstanteGlobale.GAUCHE);
                       pTmp = plateau.RetournePiece(tmp);

                        if (!(pTmp.Count == 0))
                        {
                            pionTmp = RegardePiece(pTmp);

                            // Il y a une pierre
                            if (pionTmp == null)
                            {
                                return pionTmp;
                            }
                            // Si il retourne une case de sang
                            else if (pionTmp.Get_Type() == ConstanteGlobale.CASEDESANG)
                            {
                                pionTmp = null;
                            }
                            else
                            {
                                return pionTmp;
                            }
                        }
                        if (tmp.X == 0)
                        {
                            return pionTmp;
                        }
                    }
                    return pionTmp;

                case ConstanteGlobale.DROITE:
                    while (tmp.X < 16)
                    {
                        tmp.ChangePosition(ConstanteGlobale.DROITE);


                        pTmp = plateau.RetournePiece(tmp);

                        if (!(pTmp.Count == 0))
                        {
                            pionTmp = RegardePiece(pTmp);

                            // Il y a une pierre
                            if (pionTmp == null)
                            {
                                return pionTmp;
                            }
                            // Si il retourne une case de sang
                            else if (pionTmp.Get_Type() == ConstanteGlobale.CASEDESANG)
                            {
                                pionTmp = null;
                            }
                            else
                            {
                                return pionTmp;
                            }
                        }
                        if (tmp.X == 15)
                        {
                            return pionTmp;
                        }
                    }
                    return pionTmp;

                case ConstanteGlobale.MONTE:
                    while (tmp.Y > 0)
                    {
                        tmp.ChangePosition(ConstanteGlobale.MONTE);
                        pTmp = plateau.RetournePiece(tmp);

                        if (!(pTmp.Count == 0))
                        {
                            pionTmp = RegardePiece(pTmp);

                            // Il y a une pierre
                            if (pionTmp == null)
                            {
                                return pionTmp;
                            }
                            // Si il retourne une case de sang
                            else if (pionTmp.Get_Type() == ConstanteGlobale.CASEDESANG)
                            {
                                pionTmp = null;
                            }
                            else
                            {
                                return pionTmp;
                            }
                        }
                        if (tmp.Y == 0)
                        {
                            return pionTmp;
                        }
                    }
                    return pionTmp;

                case ConstanteGlobale.DESCEND:
                    while (tmp.Y < 11)
                    {
                        tmp.ChangePosition(ConstanteGlobale.DESCEND);
                        pTmp = plateau.RetournePiece(tmp);

                        if (!(pTmp.Count == 0))
                        {
                            pionTmp = RegardePiece(pTmp);

                            // Il y a une pierre
                            if (pionTmp == null)
                            {
                                return pionTmp;
                            }
                            // Si il retourne une case de sang
                            else if (pionTmp.Get_Type() == ConstanteGlobale.CASEDESANG)
                            {
                                pionTmp = null;
                            }
                            else
                            {
                                return pionTmp;
                            }
                        }
                        if(tmp.Y == 10)
                        {
                            return pionTmp;
                        }
                    }
                    return pionTmp;


            }
            return pionTmp;
        }

        public virtual Piece RegardePiece(List<Piece> pTmp)
        {
          Piece tmp = null;
            if (pTmp.Count > 1)
            {
                //Il y a une pierre on voit pas plus loin
                if (pTmp[0].Get_Type() == ConstanteGlobale.PIERRE)
                {
                    return tmp;
                }
                //Il y a une pierre on voit pas plus loin
                else if (pTmp[1].Get_Type() == ConstanteGlobale.PIERRE)
                {
                    return tmp;
                }
                //Il y a un pion on le retourne
                else if (pTmp[0].Get_Type() == ConstanteGlobale.PION)
                {
                    return pTmp[0];
                }
                //Il y a un pion on le retourne
                else if (pTmp[1].Get_Type() == ConstanteGlobale.PION)
                {
                    return pTmp[1];
                }
                //Il y a un case de sang on la retourne
                else if (pTmp[0].Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    return pTmp[0];
                }
                //Il y a un case de sang on la retourne
                else if (pTmp[1].Get_Type() == ConstanteGlobale.CASEDESANG)
                {
                    return pTmp[1];
                }

            }
            else
            {
                //Il y a une pierre on voit pas plus loin
                if (pTmp[0].Get_Type() == ConstanteGlobale.PIERRE)
                {
                    return tmp;
                }
                //Il y a un pion on le retourne
                else if (pTmp[0].Get_Type() == ConstanteGlobale.PION)
                {
                    return pTmp[0];
                }
                else
                {
                    return pTmp[0];
                }
            }
            return tmp;
        }

        public virtual int CompteDistance(Piece pion)
        {
            int tmp;
            // Si il n'y pas de pion
            if (pion == null)
            {
                return -1;
            }
            // Calcule la distance
            else
            {
                tmp = Math.Abs(Position.X - pion.Position.X);
                tmp = tmp + Math.Abs(Position.Y - pion.Position.Y);
                return tmp;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Monstre m = obj as Monstre;

            if (m == null)
            {
                return false;
            }

            return this.idMonstre == m.idMonstre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
