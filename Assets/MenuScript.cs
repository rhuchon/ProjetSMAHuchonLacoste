using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class MenuScript : MonoBehaviour
    {
        Game game;
        InputField textBuveur;

        public void NewGame()
        {
            InputField[] texts;
            texts = GetComponentsInChildren<InputField>();

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "InputFieldBuveur")
                {
                    game.nbBuveur = int.Parse(texts[i].text);
                }
            }

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "InputFieldDanseur")
                {
                    game.nbDanseur = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "InputFieldDragueurBuveur")
                {
                    game.nbDragueur = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "InputFieldDureeEtat")
                {
                    game.dureeEtat = int.Parse(texts[i].text);
                }
            } 

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].name == "InputFieldDureeSimulation")
                {
                    game.dureeSimulation = int.Parse(texts[i].text);
                }
            } 
            
            
                                     
            Application.LoadLevel("GamePlay");
            

        }
    }
}