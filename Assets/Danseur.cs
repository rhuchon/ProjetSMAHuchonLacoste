using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Danseur : Personne
    {

        // Use this for initialization
        public Danseur()
        {
            etatCourant = "danser";
            probaBoire = 0.1;
            probaDanser = 0.7;
            probaParler = 0.1;
            probaTable = 0.0;
            probaToilette = 0.1;
            variationEnvieBoire = 0.02;
            variationEnvieDanser = 0.06;
            variationEnvieParler = 0.02;
            variationEnvieTable = 0.02;
            variationEnvieToilette = 0.02;
        }
    }
}