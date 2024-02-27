using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TetrinoFigure { L, Z, I, O, T }

public class my_tetrino_data : MonoBehaviour
{
    private GameObject pref_cube;

    private GameObject[] my_tetrino_array;

    private int my_rotation;

    private TetrinoFigure my_type;


    private void Awake()
    {
        my_rotation = 0;
        my_tetrino_array = new GameObject[4];


        pref_cube = Resources.Load("my_prefab/my_prefab_cube") as GameObject;

    }



    public GameObject[] GetTitrinoArray {get { return my_tetrino_array; } }

    public void MyRotation(bool _isPositive)
    {
        if(_isPositive)
        {
            my_rotation++;
            my_rotation = my_rotation % 4;
        }
        else
        {
            my_rotation--;
            if (my_rotation < 0)
                my_rotation = 3;
        }

        MyRotationType(my_type, my_rotation); 
    }

    private void MyRotationType(TetrinoFigure _figure, int _rot)
    {
        switch (_rot)
        {
            case 0:
                if(_figure == TetrinoFigure.L)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0,0,0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(1, -1, 0);
                }
                
                else if(_figure == TetrinoFigure.T)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, 1, 0);
                }

                else if (_figure == TetrinoFigure.I)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -2, 0);
                }

                else if (_figure == TetrinoFigure.Z)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(1, 0, 0);
                }

                else if (_figure == TetrinoFigure.O)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -1, 0);
                }
                break;

            case 1:
                if (_figure == TetrinoFigure.L)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(1, 1, 0);
                }

                else if (_figure == TetrinoFigure.T)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(-1, 0, 0);
                }

                else if (_figure == TetrinoFigure.I)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(2, 0, 0);
                }

                else if (_figure == TetrinoFigure.Z)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, 1, 0);
                }

                else if (_figure == TetrinoFigure.O)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -1, 0);
                }
                break;

            case 2:
                if (_figure == TetrinoFigure.L)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(-1, 1, 0);
                }

                else if (_figure == TetrinoFigure.T)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -1, 0);
                }

                else if (_figure == TetrinoFigure.I)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -2, 0);
                }

                else if (_figure == TetrinoFigure.Z)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(1, 0, 0);
                }

                else if (_figure == TetrinoFigure.O)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -1, 0);
                }
                break;

            case 3:
                if (_figure == TetrinoFigure.L)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(-1, -1, 0);
                }

                else if (_figure == TetrinoFigure.T)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(0, 1, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(0, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(1, 0, 0);
                }

                else if (_figure == TetrinoFigure.I)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(2, 0, 0);
                }

                else if (_figure == TetrinoFigure.Z)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, 1, 0);
                }

                else if (_figure == TetrinoFigure.O)
                {
                    my_tetrino_array[0].transform.localPosition = new Vector3(0, 0, 0);
                    my_tetrino_array[1].transform.localPosition = new Vector3(-1, 0, 0);
                    my_tetrino_array[2].transform.localPosition = new Vector3(-1, -1, 0);
                    my_tetrino_array[3].transform.localPosition = new Vector3(0, -1, 0);
                }
                break;


            default: break;
        }

    }

    public void MyInitialize(TetrinoFigure _mytype)
    {

        for (int ind = 0; ind < transform.childCount; ind++)
            Destroy(transform.GetChild(ind).gameObject);

        switch(_mytype)
        {
            case TetrinoFigure.L:
                my_type = _mytype;
                GameObject obl = Instantiate(pref_cube, new Vector3(), Quaternion.identity);
                obl.AddComponent<my_tetrino_segment>();
                obl.transform.SetParent(transform, false);

                GameObject obl2 = Instantiate(pref_cube, new Vector3(0, 1, 0), Quaternion.identity);
                obl2.AddComponent<my_tetrino_segment>();
                obl2.transform.SetParent(transform, false);

                GameObject obl3 = Instantiate(pref_cube, new Vector3(0, -1, 0), Quaternion.identity);
                obl3.AddComponent<my_tetrino_segment>();
                obl3.transform.SetParent(transform, false);

                GameObject obl4 = Instantiate(pref_cube, new Vector3(1, -1, 0), Quaternion.identity);
                obl4.AddComponent<my_tetrino_segment>();
                obl4.transform.SetParent(transform, false);

                for (int ind = 0; ind < my_tetrino_array.Length; ind++)
                    my_tetrino_array[ind] = transform.GetChild(ind).gameObject;
                break;
            case TetrinoFigure.Z:
                my_type = _mytype;
                GameObject obZ = Instantiate(pref_cube, new Vector3(), Quaternion.identity);
                obZ.AddComponent<my_tetrino_segment>();
                obZ.transform.SetParent(transform, false);

                GameObject obZ2 = Instantiate(pref_cube, new Vector3(0, 1, 0), Quaternion.identity);
                obZ2.AddComponent<my_tetrino_segment>();
                obZ2.transform.SetParent(transform, false);

                GameObject obZ3 = Instantiate(pref_cube, new Vector3(-1, 1, 0), Quaternion.identity);
                obZ3.AddComponent<my_tetrino_segment>();
                obZ3.transform.SetParent(transform, false);

                GameObject obZ4 = Instantiate(pref_cube, new Vector3(1, 0, 0), Quaternion.identity);
                obZ4.AddComponent<my_tetrino_segment>();
                obZ4.transform.SetParent(transform, false);

                for (int ind = 0; ind < my_tetrino_array.Length; ind++)
                    my_tetrino_array[ind] = transform.GetChild(ind).gameObject;
                break;
            case TetrinoFigure.I:
                my_type = _mytype;
                GameObject obI = Instantiate(pref_cube, new Vector3(), Quaternion.identity);
                obI.AddComponent<my_tetrino_segment>();
                obI.transform.SetParent(transform, false);

                GameObject obI2 = Instantiate(pref_cube, new Vector3(0, -1, 0), Quaternion.identity);
                obI2.AddComponent<my_tetrino_segment>();
                obI2.transform.SetParent(transform, false);

                GameObject obI3 = Instantiate(pref_cube, new Vector3(0, 1, 0), Quaternion.identity);
                obI3.AddComponent<my_tetrino_segment>();
                obI3.transform.SetParent(transform, false);

                GameObject obI4 = Instantiate(pref_cube, new Vector3(0, 1, 0), Quaternion.identity);
                obI4.AddComponent<my_tetrino_segment>();
                obI4.transform.SetParent(transform, false);

                for (int ind = 0; ind < my_tetrino_array.Length; ind++)
                    my_tetrino_array[ind] = transform.GetChild(ind).gameObject;
                break;
            case TetrinoFigure.O:
                my_type = _mytype;
                GameObject obO = Instantiate(pref_cube, new Vector3(), Quaternion.identity);
                obO.AddComponent<my_tetrino_segment>();
                obO.transform.SetParent(transform, false);

                GameObject obO2 = Instantiate(pref_cube, new Vector3(-1, 0, 0), Quaternion.identity);
                obO2.AddComponent<my_tetrino_segment>();
                obO2.transform.SetParent(transform, false);

                GameObject obO3 = Instantiate(pref_cube, new Vector3(-1, -1, 0), Quaternion.identity);
                obO3.AddComponent<my_tetrino_segment>();
                obO3.transform.SetParent(transform, false);

                GameObject obO4 = Instantiate(pref_cube, new Vector3(0, -1, 0), Quaternion.identity);
                obO4.AddComponent<my_tetrino_segment>();
                obO4.transform.SetParent(transform, false);

                for (int ind = 0; ind < my_tetrino_array.Length; ind++)
                    my_tetrino_array[ind] = transform.GetChild(ind).gameObject;
                break;
            case TetrinoFigure.T:
                my_type = _mytype;
                GameObject obT = Instantiate(pref_cube, new Vector3(), Quaternion.identity);
                obT.AddComponent<my_tetrino_segment>();
                obT.transform.SetParent(transform, false);

                GameObject obT2 = Instantiate(pref_cube, new Vector3(1, 0, 0), Quaternion.identity);
                obT2.AddComponent<my_tetrino_segment>();
                obT2.transform.SetParent(transform, false);

                GameObject obT3 = Instantiate(pref_cube, new Vector3(-1, 0, 0), Quaternion.identity);
                obT3.AddComponent<my_tetrino_segment>();
                obT3.transform.SetParent(transform, false);

                GameObject obT4 = Instantiate(pref_cube, new Vector3(0, 1, 0), Quaternion.identity);
                obT4.AddComponent<my_tetrino_segment>();
                obT4.transform.SetParent(transform, false);

                for (int ind = 0; ind < my_tetrino_array.Length; ind++)
                    my_tetrino_array[ind] = transform.GetChild(ind).gameObject;
                break;
            default:
                break;
        }



    }




}
