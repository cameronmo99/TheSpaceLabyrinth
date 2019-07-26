using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMaze : MazeGen
{
    // Start is called before the first frame update
    void Start()
    {
        //Spawns Maze For Main Menu
        WantedRows = 20;
        WantedColumns = 20;
        GenerateMaze();
        SpawnWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
