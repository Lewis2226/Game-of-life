using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLifeManager : MonoBehaviour
{
    public Color AliveColor;
    public Color DeadColor;
    public int cellNum;
    [SerializeField] private GameObject cellPrefab;
    bool[,] totalCells;
    [SerializeField]private float TimeToWait; 
    void Start()
    {
        totalCells = new bool[cellNum, cellNum];
        LifeGiver();
        Invoke("StartGameofLife", 4f);

    }

    void LifeGiver()//Para hacer pruebas del juego de la vida
    {
        int rnd;
        for (int i = 0; i < cellNum; i++)
        {
            for (int j = 0; j < cellNum; j++)
            {
              rnd = Random.Range(0, 2);
              if (rnd == 0)//La c�lula esta muerta
              {
                 totalCells[i, j] = true;
              }
              else//La c�lula esta muerta
              {
                 totalCells[i, j] = false;
              }
            }
        }
    }

    int NeighborsAlive(int x, int y)//Cuenta el total de c�lulas vivas alrededor de una c�lula en especial
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

                if (totalCells[i, j]) // Si la c�lula esta viva
                {
                    if (aliveCells < 2 || aliveCells > 3)//Muere si hay subpoblaci�n o sobrepoblaci�n
                    {
                        nextGeneration[i, j] = false;
                    }
                    else if (aliveCells == 2 || aliveCells == 3)// Sobrevive si tiene 2 0 3 vecinos
                    {
                        nextGeneration[i, j] = true;
                    }
                }
                else // Si la c�lula est� muerta
                {
                    if (aliveCells == 3) //Nace una nueva c�lula si hay 3 vecinos
                    {
                        nextGeneration[i, j] = true;
                    }
                }
            }
        }
        totalCells = nextGeneration;
    }

    void StartGameofLife()
    {
        StartCoroutine(NewGeneration());
    }
    IEnumerator NewGeneration()//Genera la nueva generaci�n de c�lulas despues de un lapso de tiempo
    {
        while (true)
        {
            LifeCheck();
            yield return new WaitForSeconds(TimeToWait);
        }

    }


}
