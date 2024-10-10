using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLifeManager : MonoBehaviour
{
    public Color AliveColor;
    public Color DeadColor;
    public int cellNum;
    //public SpriteRenderer render;
    public bool test;
    Dictionary<int, bool> totalCells;
    void Start()
    {
        totalCells = new Dictionary<int, bool>(); 
        LifeGiver();
    }

    void Update()
    {
        LifeCheck();
    }

    void LifeGiver() //Para hacer pruebas del juego de la vida
    {
        
        int rnd;
        for (int i = 0; i < cellNum; i++)
        {
            rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                totalCells.Add(i, true);
            }
            else
            {
                totalCells.Add(i, false);
            }
            Debug.Log($"La celula {i} esta: {totalCells[i]} "); 
        }
    }

    void LifeCheck()
    {
        
    }
}
