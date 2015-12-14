using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Game : MonoBehaviour
    {

        internal int nbPersonnes; // s'en déduit du nb de perso dans chaque état

        private Personnalite[] personnes; 
        private int[] etatsPopulation; //On stoque le nombre de personne dans le même état, une case par état
        public int nbBuveur;
        public int nbDanseur;
        public int nbDragueur;
        public System.DateTime dateSysteme;
        public System.DateTime ancienneDateMAJ;
        public System.DateTime datedebut;
        public int dureeEtat; // Temps en seconde d'un etat
        public int dureeSimulation; // Temps de la simulation en seconde
        public static int nbBuveurFin;
        public static int nbDanseurFin;
        public static int nbDragueurFin;
        public static int nbNeutreFin;


        // Use this for initialization
        public void Start()
        {
            nbBuveur = MenuScript.nbBuveur;
            nbDanseur = MenuScript.nbDanseur;
            nbDragueur = MenuScript.nbDragueur;
            dureeEtat = MenuScript.dureeEtat;
            dureeSimulation = MenuScript.dureeSimu;
            nbBuveurFin = 0;
            nbDanseurFin = 0;
            nbDragueurFin = 0;
            nbNeutreFin = 0;
            //DontDestroyOnLoad();
            //dureeEtat = 5;
            //dureeSimulation = 25;
            nbPersonnes = nbBuveur + nbDanseur + nbDragueur;
            personnes = new Personnalite[nbPersonnes];
            ancienneDateMAJ = System.DateTime.Now;
            datedebut = System.DateTime.Now;

            //TODO instancier les personnes
            for (int i = 0; i < nbBuveur; i++)
            {
                personnes[i] = new Buveur(this);
                
            }

            for (int i = nbBuveur; i < nbDanseur+nbBuveur; i++)
            {
                personnes[i] = new Danseur(this);
            }
            for (int i = nbBuveur+nbDanseur; i < nbPersonnes; i++)
            {
                personnes[i] = new Dragueur(this);
            }


            GameObject p = GameObject.Find("AIThirdPersonController");
            
            for (int i = 0; i < nbPersonnes; i++)
            {
                GameObject a = Instantiate(p);
                a.name = "bob"+(i+1);
                a.GetComponentInChildren<Comportement3D>().personnalite = personnes[i];
            }

            Destroy(p);
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

                for (int i = 0; i < personnes.Length; i++)
                {
                    if (personnes[i].personnaliteDominante == "Buveur")
                    {
                        nbBuveurFin++;
                    }
                    else if (personnes[i].personnaliteDominante == "Danseur")
                    {
                        nbDanseurFin++;
                    }
                    else if (personnes[i].personnaliteDominante == "Dragueur")
                    {
                        nbDragueurFin++;
                    }
                    else if (personnes[i].personnaliteDominante == "Neutre")
                    {
                        nbNeutreFin++;
                    }
                }

                Application.LoadLevel("MenuFin");

            }
        }
    }
}
