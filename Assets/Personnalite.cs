using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Personnalite
    {
        public Game gameActuel;
        public double probaBoire;
        public double probaDanser;
        public double probaParler;
        public double probaTable;
        public double probaToilette;
        public string etatCourant;
        public string personnaliteDominante;
        public double variationEnvieBoire;
        public double variationEnvieDanser;
        public double variationEnvieParler;
        public double variationEnvieTable;
        public double variationEnvieToilette;
        public Comportement3D comportement;

        public Personnalite(Game game)
        {
            gameActuel = game;
            //VariationPersonnaliteDominante();
        }

        public void actionPersonnage()
        {
            bool choixDecisionPerso = (Random.value < 0.5) ? true : false; // true = fonction de l'envie personnelle, false = en fonction de l'etat de la population

            // Choix de l'action personnelle en fonction de sa personnalité propre et dynamique
            if (choixDecisionPerso)
            {
                double aleaActionPerso = Random.value; // Varie selon sa probabilité d'action allant de 0 à 1
                if (aleaActionPerso <= probaBoire) // Boire
                {
                    Boire();

                }
                else if (aleaActionPerso <= probaBoire + probaDanser) // Danser
                {
                    // Fonction Danser
                    Danser();
                }
                else if (aleaActionPerso <= probaBoire + probaDanser + probaParler) // Parler
                {
                    // Fonction parler
                    Parler();
                }
                else if (aleaActionPerso <= probaBoire + probaDanser + probaParler + probaTable) // Table
                {
                    // Fonction Table
                    Table();
                }
                else // Toilette
                {
                    Toilette();
                }

                VariationPersonnaliteDominante();
            }

            // Choix de l'action en fonction des etats courants de la population
            else
            {
                System.Random rnd = new System.Random();

                int aleaEtatsPopulation = rnd.Next(0, gameActuel.nbPersonnes);
                if (0 <=aleaEtatsPopulation && aleaEtatsPopulation <= gameActuel.nbBuveur)
                {
                    Boire();
                }
                else if (gameActuel.nbBuveur<= aleaEtatsPopulation && aleaEtatsPopulation <= gameActuel.nbBuveur+gameActuel.nbDanseur)
                {
                    Danser();
                }
                else if (gameActuel.nbBuveur + gameActuel.nbDanseur <= aleaEtatsPopulation && aleaEtatsPopulation <= gameActuel.nbPersonnes)
                {

                    Table();
                }
            }
        }

        public void VariationEnvieBoire(double variationEnvieBoire)
        {
            bool augmentationEnvie = (Random.value < 0.5) ? true : false; // détermine si l'envie augmente si true ou diminue si false
            if (augmentationEnvie)
            {
                probaBoire += variationEnvieBoire;
                probaDanser -= variationEnvieBoire * 2 / 3;
                probaParler -= variationEnvieBoire * 2 / 3;
                probaTable -= variationEnvieBoire * 2 / 3;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;

            }
            else
            {
                probaBoire -= variationEnvieBoire;
                probaDanser += variationEnvieBoire / 4;
                probaParler += variationEnvieBoire / 4;
                probaTable += variationEnvieBoire / 4;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;
            }
        }

        public void VariationEnvieDanser(double variationEnvieDanser)
        {
            bool augmentationEnvie = (Random.value < 0.5) ? true : false;
            if (augmentationEnvie)
            {
                probaBoire -= variationEnvieDanser / 4;
                probaDanser += variationEnvieDanser;
                probaParler -= variationEnvieDanser / 4;
                probaTable -= variationEnvieDanser / 4;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;

            }
            else
            {
                probaBoire += variationEnvieDanser / 4;
                probaDanser -= variationEnvieDanser;
                probaParler += variationEnvieDanser / 4;
                probaTable += variationEnvieDanser / 4;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;
            }
        }

        public void VariationEnvieParler(double variationEnvieParler)
        {
            bool augmentationEnvie = (Random.value < 0.5) ? true : false;
            if (augmentationEnvie)
            {
                probaBoire -= variationEnvieParler / 4;
                probaDanser -= variationEnvieParler / 4;
                probaParler += variationEnvieParler;
                probaTable -= variationEnvieParler / 4;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;

            }
            else
            {
                probaBoire += variationEnvieParler / 4;
                probaDanser += variationEnvieParler / 4;
                probaParler -= variationEnvieParler;
                probaTable += variationEnvieParler / 4;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;
            }
        }

        public void VariationEnvieTable(double variationEnvieTable)
        {
            bool augmentationEnvie = (Random.value < 0.5) ? true : false;
            if (augmentationEnvie)
            {
                probaBoire -= variationEnvieTable / 4;
                probaDanser -= variationEnvieTable / 4;
                probaParler -= variationEnvieTable / 4;
                probaTable += variationEnvieTable;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;

            }
            else
            {
                probaBoire += variationEnvieTable / 4;
                probaDanser += variationEnvieTable / 4;
                probaParler += variationEnvieTable / 4;
                probaTable -= variationEnvieTable;
                probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;
            }
        }

        public void VariationEnvieToilette(double variationEnvieToilette)
        {
            probaBoire += variationEnvieToilette / 4;
            probaDanser += variationEnvieToilette / 4;
            probaParler += variationEnvieToilette / 4;
            probaTable += variationEnvieToilette / 4;
            probaToilette = 1 - probaBoire - probaDanser - probaParler - probaTable;
        }

        public void VariationPersonnaliteDominante()
        {
            if (probaBoire >= 0.5)
            {
                personnaliteDominante = "buveur";
            }
            else if (probaDanser >= 0.5)
            {
                personnaliteDominante = "danseur";

            }
            else if ((probaParler + probaTable) >= 0.5)
            {
                personnaliteDominante = "dragueur";

            }

            else { personnaliteDominante = "neutre"; }
        }

        public void Boire()
        {
            etatCourant = "boire";
            VariationEnvieBoire(variationEnvieBoire);
        }

        public void Danser()
        {
            etatCourant = "danser";
            VariationEnvieDanser(variationEnvieDanser);
        }
        public void Parler()
        {
            etatCourant = "parler";
            VariationEnvieParler(variationEnvieParler);
        }
        public void Table()
        {
            etatCourant = "goTable";
            VariationEnvieTable(variationEnvieTable);
        }
        public void Toilette()
        {
            etatCourant = "goToilette";
            VariationEnvieToilette(variationEnvieToilette);
        }
    }
}