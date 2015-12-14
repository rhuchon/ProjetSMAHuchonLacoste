using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class MenuScript : MonoBehaviour
    {
        public static int nbBuveur;
        public static int nbDanseur;
        public static int nbDragueur;
        public static int dureeEtat;
        public static int dureeSimu;

        public void NewGame()
        {
            Text[] texts;
            texts = GetComponentsInChildren<Text>();

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "NbBuveur")
                {
                    nbBuveur = int.Parse(texts[i].text);
                }
            }

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "NbDanseur")
                {
                    nbDanseur = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "NbDragueur")
                {
                    nbDragueur = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "DureeEtat")
                {
                    dureeEtat = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "DureeSimu")
                {
                    dureeSimu = int.Parse(texts[i].text);
                }


            }

            //DontDestroyOnLoad(this);
            Application.LoadLevel("GamePlay");
            
        }
    }
}