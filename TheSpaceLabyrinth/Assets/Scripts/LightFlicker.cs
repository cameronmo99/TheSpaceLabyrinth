using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public float LowRandom;
    public float HighRandom;
    public float RandomNumber;
    //public GameObject TheLight;
    public Light LightComponant;
    public float LightNumber;
    public float RColour;
    public float GColour;
    public float BColour;
    public float ColourHigh = 1;
    public float ColourLow = 0;


	void Start ()
    {
        //TheLight = GameObject.Find("Light" + LightNumber);
        LightComponant = GetComponent<Light>();



        StartCoroutine ("Flicker");
	}

    IEnumerator Flicker()
    {
        while(true)
        {
            //Make the Light Flicker Different Colours
            RandomNumber = Random.Range(LowRandom, HighRandom);

            LightComponant.enabled = true;

            RColour = Random.Range(ColourLow, ColourHigh);
            GColour = Random.Range(ColourLow, ColourHigh);
            BColour = Random.Range(ColourLow, ColourHigh);

            LightComponant.color = new Color(RColour, GColour, BColour);





            yield return new WaitForSeconds(RandomNumber);

            RandomNumber = Random.Range(LowRandom, HighRandom);

            LightComponant.enabled = false;

            yield return new WaitForSeconds(RandomNumber);
        }
    }

}
