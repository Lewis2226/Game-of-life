using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameLifeManager : MonoBehaviour
{
    public Color AliveColor;
    public Color DeadColor;
    public int cellNum;
    [SerializeField] private GameObject cellPrefab;
    private GameObject[,] cellsOnScreen; 
    bool[,] totalCells;
    [SerializeField]private float timeToWait;
    bool startedGame = false;

    void Start()
    {
      totalCells = new bool[cellNum, cellNum];
      CreateCell();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !startedGame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.FloorToInt(mousePos.x);
            int y = Mathf.FloorToInt(mousePos.y);

            if(x > 0 && x< cellNum && y >0 && y < cellNum) 
            {
                totalCells[x, y] =! totalCells[x,y];
                ShowSimulation();
            }
        }
    }

    public void LifeGiver()//Para hacer pruebas del juego de la vida
    {
        int rnd;
        for (int i = 0; i < cellNum; i++)
        {
            for (int j = 0; j < cellNum; j++)
            {
              rnd = Random.Range(0, 2);
              if (rnd == 0)//La célula esta muerta
              {
                 totalCells[i, j] = true;
              }
              else//La célula esta muerta
              {
                 totalCells[i, j] = false;
              }
            }
        }
    }

    int NeighborsAlive(int x, int y)//Cuenta el total de células vivas alrededor de una célula en especial
    {
        int neighborslife = 0;

        for(int i = -1; i <= 1; i++)  
        {
            for(int j = -1; j <= 1; j++)  
            {
                if(i == 0 && j == 0)
                    continue;  

                int PosX = x + i;
                int PosY = y + j;

                if (PosX >= 0 && PosX < totalCells.GetLength(0) && PosY >= 0 && PosY < totalCells.GetLength(1))
                {
                    if (totalCells[PosX, PosY])  
                    {
                        neighborslife++;
                    }
                }
            }
        }
        return neighborslife;
    }

    void LifeCheck()//Aplica las reglas de Conway
    {
        bool[,] nextGeneration = new bool[cellNum, cellNum];
        for (int i = 0; i < cellNum; i++) 
        {
            for (int j = 0; j < cellNum; j++) 
            {
                int aliveCells = NeighborsAlive(i, j);

                if (totalCells[i, j]) // Si la célula esta viva
                {
                    if (aliveCells < 2 || aliveCells > 3)//Muere si hay subpoblación o sobrepoblación
                    {
                        nextGeneration[i, j] = false;
                    }
                    else if (aliveCells == 2 || aliveCells == 3)// Sobrevive si tiene 2 0 3 vecinos
                    {
                        nextGeneration[i, j] = true;
                    }
                }
                else // Si la célula está muerta
                {
                    if (aliveCells == 3) //Nace una nueva célula si hay 3 vecinos
                    {
                        nextGeneration[i, j] = true;
                    }
                }
            }
        }
        totalCells = nextGeneration;
    }

    public void StartGameofLife()
    {
      StartCoroutine(NewGeneration());
    }
    IEnumerator NewGeneration()//Genera la nueva generación de células despues de un lapso de tiempo
    {
        while (true)
        {
            LifeCheck();
            ShowSimulation();
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void CreateCell() //Crea todas las células y las agrega al arreglo de celulas en pantalla. 
    {
        cellsOnScreen = new GameObject[cellNum, cellNum];
        for ( int i = 0;i < cellNum; i++)
        {
            for(int j = 0;j < cellNum; j++)
            {
                Vector3 position = new Vector3(i, j, 0);
                GameObject cell = Instantiate(cellPrefab,position, Quaternion.identity);
                cell.GetComponent<SpriteRenderer>().color= DeadColor;
                cellsOnScreen[i,j] = cell;
            }
        }
    }

    public void ShowSimulation()
    {

        for(int i = 0; i< cellNum; i++)
        {
            for(int j = 0; j < cellNum; j++)
            {
                if (totalCells[i, j])
                {
                    cellsOnScreen[i,j].GetComponent<SpriteRenderer>().color = AliveColor;
                }
                else
                {
                    cellsOnScreen[i, j].GetComponent<SpriteRenderer>().color = DeadColor;
                }
            }
        }
    }

    public void PauseGame()
    {
        startedGame = !startedGame;
    }
}
