using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiseAJourNB : MonoBehaviour {


    
	// Use this for initialization
	void Start () {

        Slider[] sliders = GetComponents<Slider>();
        for (int i = 0; i < sliders.Length; i++)
        {
            if(sliders[i].name == "SliderBuveur")
            {
                sliders[i].value = 40;
                int nb = (int)sliders[i].value;
                GameObject.Find("NbBuveur").GetComponent<Text>().text = nb.ToString();
            }
            if(sliders[i].name == "SliderDanseur")
            {
                sliders[i].value = 40;
                int nb = (int)sliders[i].value;
                GameObject.Find("NbDanseur").GetComponent<Text>().text = nb.ToString();
            }
            if(sliders[i].name == "SliderDragueur")
            {
                sliders[i].value = 40;
                int nb = (int)sliders[i].value;
                GameObject.Find("NbDragueur").GetComponent<Text>().text = nb.ToString();
            }
            if(sliders[i].name == "SliderDureeEtat")
            {
                sliders[i].value = 8;
                int nb = (int)sliders[i].value;
                GameObject.Find("DureeEtat").GetComponent<Text>().text = nb.ToString();
            }
            if(sliders[i].name == "SliderDureeSimu")
            {
                sliders[i].value = 150;
                int nb = (int)sliders[i].value;
                GameObject.Find("DureeSimu").GetComponent<Text>().text = nb.ToString();
            }
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void MAJnbBuveur()
    {
        if (GetComponent<Slider>().name == "SliderBuveur")
        {
            int nb = (int)GetComponent<Slider>().value;
            GameObject.Find("NbBuveur").GetComponent<Text>().text = nb.ToString();
        }
        if (GetComponent<Slider>().name == "SliderDanseur")
        {
            int nb = (int)GetComponent<Slider>().value;
            GameObject.Find("NbDanseur").GetComponent<Text>().text = nb.ToString();
        }
        if (GetComponent<Slider>().name == "SliderDragueur")
        {
            int nb = (int)GetComponent<Slider>().value;
            GameObject.Find("NbDragueur").GetComponent<Text>().text = nb.ToString();
        }
        if (GetComponent<Slider>().name == "SliderDureeEtat")
        {
            int nb = (int)GetComponent<Slider>().value;
            GameObject.Find("DureeEtat").GetComponent<Text>().text = nb.ToString();
        }
        if (GetComponent<Slider>().name == "SliderDureeSimu")
        {
            int nb = (int)GetComponent<Slider>().value;
            GameObject.Find("DureeSimu").GetComponent<Text>().text = nb.ToString();
        }
    }
   

}
