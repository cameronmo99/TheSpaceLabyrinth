using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{

    public List<GameObject> LightsList;
    public int ListAmount;
    public GameObject CurrentLightGameObject;
    public int LightSelector;
    public GameObject PlayersLight;
    public bool PlayerEntered;

    void Start()
    {
        ListAmount = LightsList.Count;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" && PlayerEntered == false)
        {
            PlayerEntered = true;
            StartCoroutine("StartLightsOff");
        }
    }





    IEnumerator StartLightsOff()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            CurrentLightGameObject = LightsList[LightSelector];
            CurrentLightGameObject.gameObject.SetActive(false);

            if (LightSelector == ListAmount)
            {
                Debug.Log("123");
                PlayersLight.gameObject.SetActive(true);
                StopCoroutine("StartLightsOff");
            }


            LightSelector++;
        }
    }




}


