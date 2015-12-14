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
        // Use this for initialization
        void Start()
        {
            nbBuveurFin = Game.nbBuveurFin;
            nbDanseurFin=  Game.nbDanseurFin;
            nbDragueurFin = Game.nbDragueurFin;
            nbNeutreFin = Game.nbNeutreFin;
            nbBuveur = MenuScript.nbBuveur;
            nbDanseur = MenuScript.nbDanseur;
            nbDragueur = MenuScript.nbDragueur;

            Text[] texts = GetComponents<Text>();

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "TextBuveur")
                {
                    texts[i].text = nbBuveur.ToString();
                }
                if (texts[i].name == "TextDanseur")
                {
                    texts[i].text = nbDanseur.ToString();
                }
                if (texts[i].name == "TextDragueur")
                {
                    texts[i].text = nbDragueur.ToString();
                }
                if (texts[i].name == "TextBuveurFin")
                {
                    texts[i].text = nbBuveurFin.ToString();
                }
                if (texts[i].name == "TextDanseurFin")
                {
                    texts[i].text = nbDanseurFin.ToString();
                }
                if (texts[i].name == "TextDragueurFin")
                {
                    texts[i].text = nbDragueurFin.ToString();
                }
                if (texts[i].name == "TextNeutreFin")
                {
                    texts[i].text = nbNeutreFin.ToString();
                }
            }
        }
    }
}