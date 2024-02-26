using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private const int wid = 13, hei = 21;
    private float my_step = 1;

    private GameObject pref_tetrino;
    private my_tetrino_figure my_figure;


    private void Start()
    {
        pref_tetrino = Resources.Load("my_prefab/my_tetrino_figure") as GameObject;

        CreteFigure(TetrinoFigure.T);
    }


    private void CreteFigure(TetrinoFigure _figure)
    {
        my_figure = Instantiate(pref_tetrino, new Vector3(my_step * 6, my_step * (hei - 2),0),
           Quaternion.identity).GetComponent<my_tetrino_figure>();

        my_figure.GetComponentInChildren<my_tetrino_data>().MyInitialize(_figure);
    }


}
