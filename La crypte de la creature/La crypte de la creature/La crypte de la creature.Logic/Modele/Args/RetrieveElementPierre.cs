using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    //usage pour code c#
    public class RetrieveElementPierre
    {
       public bool CasePresent;
       public int index;
       public Position pACote;
       public Position posTmp;
       public List<Piece> pTmp;
       public Deplacement deplacement;
    }
}
