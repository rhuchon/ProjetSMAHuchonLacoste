using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Game : MonoBehaviour
    {

        public int nbPersonnes;

        public Personne[] personnes;
        public string[] etatsPopulation; //On stoque le nombre de personne dans le même état, une case par état
        public System.DateTime dateSysteme;
        public System.DateTime ancienneDateMAJ;
        public int dureeEtat; // Temps en seconde d'un etat
        public int dureeSimulation; // Temps de la simulation en seconde

        // Use this for initialization
        public void Start()
        {
            dureeEtat = 10;
            int nbBuveur = 4;
            int nbDanseur = 4;
            int nbDragueur = 4;
            nbPersonnes = nbBuveur + nbDanseur + nbDragueur;
            personnes = new Personne[nbPersonnes];
            ancienneDateMAJ = System.DateTime.Now;

            //TODO instancier les personnes
            for (int i = 0; i < personnes.Length - 8; i++)
            {
                personnes[i] = new Buveur();
            }

            for (int i = 4; i < personnes.Length - 4; i++)
            {
                personnes[i] = new Danseur();
            }
            for (int i = 8; i < personnes.Length; i++)
            {
                personnes[i] = new Dragueur();
            }
            


        }

        // Update is called once per frame
        void Update()
        {
            dateSysteme = System.DateTime.Now;
            if ((dateSysteme - ancienneDateMAJ).TotalSeconds == dureeEtat)
            {
                // Mise à jour état du jeu
                ancienneDateMAJ = dateSysteme;
                for (int i = 0; i < personnes.Length; i++)
                {
                    Debug.Log("10 Secondes");
                    personnes[i].actionPersonnage();
                }

            }

            else if ((dateSysteme - ancienneDateMAJ).TotalSeconds == dureeSimulation)
            {
                // Fin du Game
            }
        }
    }
}
