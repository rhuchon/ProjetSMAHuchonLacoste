using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    
    public int[] EtatsPopulation; //On stoque le nombre de personne dans le même état, une case par état
    public System.DateTime dateSysteme;
    public System.DateTime ancienneDateMAJ;
    public int dureeEtat; // Temps en seconde d'un etat
    public int dureeSimulation; // Temps de la simulation en seconde

	// Use this for initialization
	void Start () {
        ancienneDateMAJ = System.DateTime.Now;

	}
	
	// Update is called once per frame
	void Update () {
        dateSysteme = System.DateTime.Now;
        if ((dateSysteme - ancienneDateMAJ).TotalSeconds == dureeEtat)
        {
            // Mise à jour état du jeu
            ancienneDateMAJ = dateSysteme;
        }

        else if ((dateSysteme - ancienneDateMAJ).TotalSeconds == dureeSimulation)
        {
            // Fin du Game
        }
	}
}
