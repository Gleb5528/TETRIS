using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_tetrino_figure : MonoBehaviour
{
  public void MyDropTetrino(bool _isPositive)
    {
        if(_isPositive)
            transform.Translate(0,-1,0);
        else
            transform.Translate(0, 1, 0);

    }
}
