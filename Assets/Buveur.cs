﻿using UnityEngine;
using System.Collections;

public class Buveur : Personne {

	// Use this for initialization
	void Start () {
        probaBoire = 0.65;
        probaDanser = 0.1;
        probaParler = 0.0;
        probaTable = 0.05;
        probaToilette = 0.2;
        variationEnvieBoire = 0.05;
        variationEnvieDanser = 0.02;
        variationEnvieParler = 0.02;
        variationEnvieTable = 0.02;
        variationEnvieToilette = 0.02;
	}
	
	// Update is called once per frame
	void Update () {

	}

    
}
