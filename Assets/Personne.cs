using UnityEngine;
using System.Collections;

public class Personne : MonoBehaviour {
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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
                // Fonction Boire ( Aller au bar) +  MAJ Etat courant + MAJ personnaliteDomiante si il y a lieu + Fonction Couleur si modif personnaliteDominante
                VariationEnvieBoire(variationEnvieBoire);
            }
            else if (aleaActionPerso <= probaBoire + probaDanser) // Danser
            {
                // Fonction Danser
                VariationEnvieDanser(variationEnvieDanser);
            }
            else if (aleaActionPerso <= probaBoire + probaDanser + probaParler) // Parler
            {
                // Fonction parler
                VariationEnvieParler(variationEnvieParler);
            }
            else if (aleaActionPerso <= probaBoire + probaDanser + probaParler + probaTable) // Table
            {
                // Fonction Table
                VariationEnvieTable(variationEnvieTable);
            }
            else // Toilette
            {
                VariationEnvieToilette(variationEnvieToilette);
            }

            VariationPersonnalite(); // MAJ de la couleur du personnage si sa personnalité a changé
        }
        // Choix de l'action en fonction des etats courants de la population
        else
        {
            System.Random rnd = new System.Random();

            int aleaEtatsPopulation = rnd.Next(0, gameActuel.nbPersonnes);
            if (gameActuel.etatsPopulation[aleaEtatsPopulation] == "buveur")
            {
                VariationEnvieBoire(variationEnvieBoire);
            }
            else if (gameActuel.etatsPopulation[aleaEtatsPopulation] == "danseur")
            {
                VariationEnvieDanser(variationEnvieDanser);
            }
            else if (gameActuel.etatsPopulation[aleaEtatsPopulation] == "dragueur")
            {
                VariationEnvieToilette(variationEnvieToilette);
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
            probaBoire -= variationEnvieTable  / 4;
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

    public void VariationPersonnalite()
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
    }
}
