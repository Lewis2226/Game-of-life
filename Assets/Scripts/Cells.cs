using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private bool life;

    public void setLife(bool state)
    {
        life = state;
    }
    public bool getLife()
    {
      bool _life;
      _life = life;
      return _life;
    }

    
}
