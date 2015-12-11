using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Game : MonoBehaviour
    {

        public int nbPersonnes;

        public Personnalite[] personnes;
        public string[] etatsPopulation; //On stoque le nombre de personne dans le même état, une case par état
        public System.DateTime dateSysteme;
        public System.DateTime ancienneDateMAJ;
        public System.DateTime datedebut;
        public int dureeEtat; // Temps en seconde d'un etat
        public int dureeSimulation; // Temps de la simulation en seconde

        // Use this for initialization
        public void Start()
        {
            dureeEtat = 5;
            dureeSimulation = 25;
            int nbBuveur = 4;
            int nbDanseur = 4;
            int nbDragueur = 4;
            nbPersonnes = nbBuveur + nbDanseur + nbDragueur;
            personnes = new Personnalite[nbPersonnes];
            ancienneDateMAJ = System.DateTime.Now;
            datedebut = System.DateTime.Now;

            //TODO instancier les personnes
            for (int i = 0; i < 4; i++)
            {
                personnes[i] = new Buveur();
            }

            for (int i = 4; i < 8; i++)
            {
                personnes[i] = new Danseur();
            }
            for (int i = 8; i < 12; i++)
            {
                personnes[i] = new Dragueur();
            }


            GameObject p = GameObject.Find("AIThirdPersonController");
            p.GetComponentInChildren<Comportement3D>().personnalite = personnes[0];

            for (int i = 0; i < nbPersonnes; i++)
            {
                GameObject a = Instantiate(p);
                a.name = "bob"+(i+1);
                a.GetComponentInChildren<Comportement3D>().personnalite = personnes[i];
            }

        }

        // Update is called once per frame
        void Update()
        {
            
            dateSysteme = System.DateTime.Now;
            int delai = (int)(dateSysteme - ancienneDateMAJ).TotalSeconds;
            int fin = (int)(dateSysteme - datedebut).TotalSeconds;
            if (delai == dureeEtat)
            {
                Debug.Log("10 Secondes");
                // Mise à jour état du jeu
                ancienneDateMAJ = dateSysteme;
                for (int i = 0; i < personnes.Length; i++)
                {
                    
                    personnes[i].actionPersonnage();
                }

            }

            else if (fin == dureeSimulation)
            {
                Debug.Log("Biimmmm");
            }
        }
    }
}
