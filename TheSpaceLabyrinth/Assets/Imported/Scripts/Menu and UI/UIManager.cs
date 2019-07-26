using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Scene CurrentScene;
    public Canvas MainMenuCanves;
    public Canvas SinglePlayerCanvas;
    public Canvas VSCanvas;
    public Canvas OptionsCanvas;

    public bool DisableMainCanvas;

    public float RowsWanted;
    public float ColumnsWanted;
    public float RowsWantedVS;
    public float ColumnsWantedVS;

    public Text RowSliderAmount;
    public Text ColumnSliderAmount;
    public Text RowSliderAmountVS;
    public Text ColumnSliderAmountVS;
    public Slider RowSlider;
    public Slider ColumnSlider;
    public Slider RowSliderVS;
    public Slider ColumnSliderVS;
    public GameObject Goal;
    public Collider GoalBox;
    public GameObject Player1;
    public bool SPWON;
    public bool SPLOST;
    public Slider SinglePlayerCanvasRowSlider;
    public Slider SinglePlayerCanvasColumnsSlider;
    public Slider VSCanvasRowSlider;
    public Slider VSCanvasColumnsSlider;

    public int Life = 0;

    //Stops the GameManager Getting Destroyed
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        //Gets Current Scene
        CurrentScene = SceneManager.GetActiveScene();
        Life = 0;
    }

    public void EnableCanves()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Gets Current Scene
        CurrentScene = SceneManager.GetActiveScene();


        //If the Current Scene is Main Menu Will get and set Rows and Columns
        if (CurrentScene.name == "MainMenu")
        {
           // MainMenuCanves = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
           // SinglePlayerCanvas = GameObject.Find("SinglePlayerCanvas").GetComponent<Canvas>();



          //SinglePlayerCanvasRowSlider = GameObject.Find("RowSlider").GetComponent<Slider>();
          //  RowsWanted = RowsWanted.value;
          //SinglePlayerCanvasColumnsSlider = GameObject.Find("ColumnSlider").GetComponent<Slider>();
          //  ColumnsWanted = SinglePlayerCanvasRowSlider.value;
            RowsWanted = RowSlider.value;
            ColumnsWanted = ColumnSlider.value;
          //RowSliderAmount = GameObject.Find("RowAmount").GetComponent<Text>();
          //ColumnSliderAmount = GameObject.Find("ColumnAmount").GetComponent<Text>();
            RowSliderAmount.text = RowsWanted.ToString();
            ColumnSliderAmount.text = ColumnsWanted.ToString();
            if (DisableMainCanvas == true)
            {
                MainMenuCanves.gameObject.SetActive(true);
            }

            RowsWantedVS = RowSliderVS.value;
            ColumnsWantedVS = ColumnSliderVS.value;
            RowSliderAmountVS.text = RowsWantedVS.ToString();
            ColumnSliderAmountVS.text = ColumnsWantedVS.ToString();

        }

        //If the Scene is Single Player Will load relivent Scenes
        if(CurrentScene.name == "SinglePlayer")
        {
            if (SPWON == true)
            {
                SceneManager.LoadScene("SPWON");
                SPWON = false;
                Destroy(this);
            }
            if (SPLOST == true)
            {
                SceneManager.LoadScene("SPLOST");
                SPLOST = false;
            }
            if (CurrentScene.name == "SPLOST")
            {
                Destroy(this);
                //SceneManager.LoadScene("MainMenu");
            }
        }

    }

    //Dissables all canveses and enables Single Player Menu
    public void SinglePlayerButton()
    {
        DisableMainCanvas = true;
        MainMenuCanves.gameObject.SetActive(false);
        SinglePlayerCanvas.gameObject.SetActive(true);
        DisableMainCanvas = false;
    }

    //Dissables all canveses and enables VS Menu
    public void VSButton()
    {
        DisableMainCanvas = true;
        MainMenuCanves.gameObject.SetActive(false);
        VSCanvas.gameObject.SetActive(true);
        DisableMainCanvas = false;
    }

    //Dissables all canveses and enables the Main Menu or Loads Menu SCene 

    public void BackButton()
    {
        if (CurrentScene.name == "MainMenu")
        {
            DisableMainCanvas = false;

            SinglePlayerCanvas.gameObject.SetActive(false);
            VSCanvas.gameObject.SetActive(false);
            OptionsCanvas.gameObject.SetActive(false);
            MainMenuCanves.gameObject.SetActive(true);
        }
        if (CurrentScene.name == "SinglePlayer")
        {
            DisableMainCanvas = false;

            SceneManager.LoadScene("MainMenu");
        }
    }

    //Exits Game

    public void ExitButton()
    {
        Application.Quit();
    }

    //Loads the Single Player
    public void PlaySinglePlayerGame()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    //Loads the VS Map
    public void PlayVSGame()
    {
        SceneManager.LoadScene("VS");
    }
}
