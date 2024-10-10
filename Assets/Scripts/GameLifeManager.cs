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
    public string[] totalCells; 
    void Start()
    {
        for (int i = 0; i < cellNum; i++)
        {
            totalCells[i] = $"la celula {i}, esta muerta";
            Debug.Log(totalCells[i]);
        }
    }
    /*
    public void ChangeColor(bool state)
    {
        if(state)
        {
            render.color = AliveColor;
        }

        else 
        {
            render.color= DeadColor;
        }
    }
    */

    void Update()
    {
        //ChangeColor(test);
    }
}
