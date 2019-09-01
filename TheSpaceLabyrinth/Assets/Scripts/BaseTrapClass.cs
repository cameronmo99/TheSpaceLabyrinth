using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrapClass : MonoBehaviour
{
    public Light PlayerLight;
    public GameObject Player;
    public float Speed;
    public float RandomFlickerNumber;
    public float RandomFlickerNumberLow;
    public float RandomFlickerNumberHigh;
    public bool PlayerHasEntered;
    public PlayerScriptV2 PlayerScript;

    IEnumerator TorchFlicker()
    {
        while (true)
        {

            //Makes the torch Flicker
            PlayerLight.enabled = true;

            yield return new WaitForSeconds(RandomFlickerNumber);

            RandomFlickerNumber = Random.Range(RandomFlickerNumberLow, RandomFlickerNumberHigh);

            PlayerLight.enabled = false;

            yield return new WaitForSeconds(RandomFlickerNumber);
        }
    }


}
