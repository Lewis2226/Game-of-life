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
    Hashtable totalCells; 
    void Start()
    {
        LifeGiver();
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
        LifeCheck();
    }

    void LifeGiver()
    {
        int rnd; 
        for(int i = 0; i < cellNum; i++) 
        {
            rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                totalCells.Add(i, "Celula esta muerta");   
            }
            else
            {
                totalCells.Add(i, "Celula  esta viva");
            }
            Debug.Log(totalCells[i].ToString());

        }
    }

    void LifeCheck()
    {

    }
}
