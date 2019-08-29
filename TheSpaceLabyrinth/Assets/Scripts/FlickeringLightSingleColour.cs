using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLightSingleColour : MonoBehaviour
{

    public Light LightComponant;

    public float LowRandom;
    public float HighRandom;
    public float RandomNumber;



    // Start is called before the first frame update
    void Start()
    {
        LightComponant = GetComponent<Light>();



        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            LightComponant.enabled = true;

            yield return new WaitForSeconds(RandomNumber);

            RandomNumber = Random.Range(LowRandom, HighRandom);

            LightComponant.enabled = false;

            yield return new WaitForSeconds(RandomNumber);
        }
    }
}
