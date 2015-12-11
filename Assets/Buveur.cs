using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Buveur : Personnalite
    {
        public Buveur()
        {
            etatCourant = "boire";
            probaBoire = 0.65;
            probaDanser = 0.1;
            probaParler = 0.0;
            probaTable = 0.05;
            probaToilette = 0.2;
            variationEnvieBoire = 0.05;
            variationEnvieDanser = 0.02;
            variationEnvieParler = 0.02;
            variationEnvieTable = 0.02;
            variationEnvieToilette = 0.02;
            VariationPersonnaliteDominante();
        }
    }
}
