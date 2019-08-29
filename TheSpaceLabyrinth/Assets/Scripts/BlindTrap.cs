using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindTrap : BaseTrapClass
{
    void Start()
    {
        PlayerLight = Player.GetComponent<Light>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            StartCoroutine("BlindFlicker");
        }
    }

    IEnumerator BlindFlicker()
    {
        while (true)
        {
            //PlayerLight = Player.GetComponent<Light>();
            //PlayerLight.SetActive(false);
            //PlayerLight = Player.GetComponentInChildren<Light>;
            RandomFlickerNumber = Random.Range(RandomFlickerNumberLow, RandomFlickerNumberHigh);
            yield return new WaitForSeconds(RandomFlickerNumber);
            //PlayerLight.SetActive(true);
        }


    }

}


