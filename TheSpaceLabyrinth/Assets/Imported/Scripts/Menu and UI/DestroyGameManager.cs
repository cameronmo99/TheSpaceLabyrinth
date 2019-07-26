using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameManager;

    void Start()
    {
        //Destroys the GameManager
        GameManager = GameObject.Find("GameManager");
        Destroy(GameManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
