using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class MenuFinScript : MonoBehaviour
    {
        public int nbBuveurFin;
        public int nbDanseurFin;
        public int nbDragueurFin;
        public int nbNeutreFin;
        public int nbBuveur;
        public int nbDanseur;
        public int nbDragueur;
		public int dureeSimu;
		public int dureeEtat;
        // Use this for initialization
        void Start()
        {
            nbBuveurFin = Game.nbBuveurFin;
            nbDanseurFin=  Game.nbDanseurFin;
            nbDragueurFin = Game.nbDragueurFin;
            nbNeutreFin = Game.nbNeutreFin;
			dureeSimu = MenuScript.dureeSimu;
			dureeEtat = MenuScript.dureeEtat;
            nbBuveur = MenuScript.nbBuveur;
            nbDanseur = MenuScript.nbDanseur;
            nbDragueur = MenuScript.nbDragueur;
			Text[] texts = GetComponentsInChildren<Text>();

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "NbBuveur")
                {
                    texts[i].text = nbBuveur.ToString();
                }
                if (texts[i].name == "NbDanseur")
                {
                    texts[i].text = nbDanseur.ToString();
                }
                if (texts[i].name == "NbDragueur")
                {
                    texts[i].text = nbDragueur.ToString();
                }
                if (texts[i].name == "NbBuveurFin")
                {
                    texts[i].text = nbBuveurFin.ToString();
                }
                if (texts[i].name == "NbDanseurFin")
                {
                    texts[i].text = nbDanseurFin.ToString();
                }
                if (texts[i].name == "NbDragueurFin")
                {
                    texts[i].text = nbDragueurFin.ToString();
                }
                if (texts[i].name == "NbNeutreFin")
                {
                    texts[i].text = nbNeutreFin.ToString();
                }
				if (texts[i].name == "DureeEtat") {
					texts[i].text = dureeEtat.ToString();
				}
				if (texts[i].name == "DureeSimu") {
					texts[i].text = dureeSimu.ToString();
				}
            }
        }
    }
}