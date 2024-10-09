using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLifeManager : MonoBehaviour
{
    public Color AliveColor;
    public Color DeadColor;
    public SpriteRenderer render;
    public bool test;
    void Start()
    {
        
    }

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

    void Update()
    {
        ChangeColor(test);
    }
}
