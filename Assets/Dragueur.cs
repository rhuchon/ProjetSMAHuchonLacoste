﻿using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Dragueur : Personnalite
    {
        public Dragueur(Game game) : base (game)
        {
            etatCourant = "parler";
            probaBoire = 0.05;
            probaDanser = 0.2;
            probaParler = 0.4;
            probaTable = 0.3;
            probaToilette = 0.05;
            variationEnvieBoire = 0.02;
            variationEnvieDanser = 0.02;
            variationEnvieParler = 0.05;
            variationEnvieTable = 0.02;
            variationEnvieToilette = 0.02;
            VariationPersonnaliteDominante();
           
        }

    }
}