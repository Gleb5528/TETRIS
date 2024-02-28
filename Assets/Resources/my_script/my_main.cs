﻿using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public struct MyHud
{
    public Text gameOverScoreText;

    public Text txt_score;
    public int my_int_score;

    public Text txt_highscore;
    public int my_int_highscore;

    public Text txt_line;
    private int my_int_line;

    public Text txt_level;

    public int my_int_level { get; private set; }
    public float my_speed;
    private int my_counter_line;

  
    public void AddScore(int _score)
    {
        my_int_score += _score;
        txt_score.text = my_int_score.ToString();
        
        txt_highscore.text = my_int_score.ToString();
        gameOverScoreText.text = my_int_score.ToString();
    }
    public void Tet()
    {
        //txt_score.text= "Score: " + gameOverScoreText;// Обновляем текстовое поле на панели GameOverPanel
        Debug.Log("Игра закрылась" + my_int_score);
        


    }
    public void AddLine(int _line)
    {
        my_int_line += _line;
        txt_line.text = my_int_line.ToString();

        my_counter_line += _line;
        if (my_counter_line > 9)
            AddLevel(1);
        my_counter_line = my_counter_line % 10;
    }
    public void AddLevel(int _level)
    {
        my_int_level += _level;
        txt_level.text = my_int_level.ToString();
        my_speed -= my_int_level > 5 ? 0.02f : 0.05f;
    }
}
public class my_main : MonoBehaviour
{
    // Поля, связанные с интерфейсом и объектами игры
    public Text gameOverScoreText;
    public Text txt_score;
    public int my_int_score;
    public GameObject GameOverPanel;
    private const int wid = 13, hei = 21;
    private float my_step = 1;
    private float my_curr_time;

    private GameObject pref_tetrino;
    private Object pref_tetrino_object;

    private my_tetrino_figure my_figure;
    private TetrinoFigure my_figure_random;

    private my_tetrino_element[,] my_array;
    private MyHud my_hub;

    private my_tittle_figure my_tittle;

    // Метод Start вызывается перед первым обновлением кадра
    private void Start()
    {
        my_curr_time = 0;
        my_array = new my_tetrino_element[wid, hei];

        pref_tetrino = Resources.Load("my_prefab/my_tetrino_figure") as GameObject;
        pref_tetrino_object = Resources.Load("my_prefab/my_prefab_tetrino_o");
        my_tittle = FindObjectOfType<my_tittle_figure>();

        my_hub = new MyHud();

        my_hub.txt_score = GameObject.FindGameObjectWithTag("my_score").GetComponent<Text>();
        my_hub.txt_highscore = GameObject.FindGameObjectWithTag("my_highscore").GetComponent<Text>();
        my_hub.txt_line = GameObject.FindGameObjectWithTag("my_line").GetComponent<Text>();
        my_hub.txt_level = GameObject.FindGameObjectWithTag("my_level").GetComponent<Text>();
        my_hub.gameOverScoreText = GameObject.FindGameObjectWithTag("my_score").GetComponent<Text>();
        my_hub.my_speed = 0.5f;
        my_hub.AddLevel(1);
        
        my_figure_random = CreateRandomFigure();
        CreteFigure(my_figure_random);
        my_figure_random = CreateRandomFigure();

        my_tittle.GetComponentInChildren<my_tetrino_data>().MyInitialize(my_figure_random);

        for (int y = 0; y < hei; y++)
            for (int x = 0; x < wid; x++)
            {
                GameObject go = Instantiate(pref_tetrino_object, new Vector3(x * my_step, y * my_step, 0),
                    Quaternion.identity) as GameObject;


                my_array[x, y] = go.GetComponent<my_tetrino_element>();
            }
    }
 
    private TetrinoFigure CreateRandomFigure()
    {
        return (TetrinoFigure)Random.Range(0, 5);
    }
    private void CreteFigure(TetrinoFigure _figure)
    {
        my_figure = Instantiate(pref_tetrino, new Vector3(my_step * 6, my_step * (hei - 2), 0),
           Quaternion.identity).GetComponent<my_tetrino_figure>();

        my_figure.GetComponentInChildren<my_tetrino_data>().MyInitialize(_figure);

        StartCoroutine(my_update(my_hub.my_speed));
    }
    private IEnumerator my_update(float _time)
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);
            my_figure.MyDropTetrino(true);

            if (CheckPreIntersect(my_figure))
                break;
        }

        AddToAray();
        Destroy(my_figure.gameObject);
        MyRemoveFullLine();

        if (!IsGameOver())
        {
            CreteFigure(my_figure_random);
            my_figure_random = CreateRandomFigure();
            my_tittle.GetComponentInChildren<my_tetrino_data>().MyInitialize(my_figure_random);
        }
    }
    private void AddToAray()
    {
        GameObject[] go = my_figure.GetComponentInChildren<my_tetrino_data>().GetTitrinoArray;

        for (int ind = 0; ind < go.Length; ind++)
        {
            int x = (int)go[ind].transform.position.x;
            int y = (int)go[ind].transform.position.y;


            my_array[x, y].set_tetrino_active(true);
           
        }
    }
    private void MyRemoveFullLine()
    {
        int[] removeline = MyCheckFullLine();

        for (int ind = 0; ind < removeline.Length; ind++)
        {
            for (int x = 0; x < wid; x++)
                my_array[x, removeline[ind]].set_tetrino_active(false);

            my_hub.AddScore(removeline.Length == 4 ? 750 : 350);
        }

        if (removeline.Length != 0)
        {
            int[] empty_line = MyCheckEmptyLine();
            bool[,] arr_new_tetrino = new bool[wid, hei];
            int start_y = 0;
            my_hub.AddLine(removeline.Length);
            for (int y = 0; y < hei; y++)
            {
                if (MySkipTheLine(empty_line, y))
                    continue;
                for (int x = 0; x < wid; x++)

                    arr_new_tetrino[x, start_y] = my_array[x, y].get_isActive_tetrino();
                start_y++;
            }
            MySetNewTetrinoArray(arr_new_tetrino);
        }
    }
    public void MyOnStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MyOnPause(bool _isPause)
    {
        Time.timeScale = _isPause ? 0 : 1;
    }
    
    private bool IsGameOver()
    {
        if (my_array == null)
        {
            Debug.LogError("Массив my_array не был инициализирован!");
            return true; // Или верните true, если это нужно для вашей логики
        }
        for (int ind = 0; ind < wid; ind++)
        {
            if (my_array[ind, hei - 3].get_isActive_tetrino())
            {
                GameOverPanel.SetActive(true);
                // Выводим количество набранных очков при завершении игры
                my_hub.Tet();
                
                return true; // Игра завершена             
            }       
        }
        return false;  
    }
    private void MySetNewTetrinoArray(bool[,] _arr_new)
    {
        for (int y = 0; y < hei; y++)
            for (int x = 0; x < wid; x++)
                my_array[x, y].set_tetrino_active(_arr_new[x, y]);
    }
    private bool MySkipTheLine(int[] _emty_line, int _y)
    {
        for (int y = 0; y < _emty_line.Length; y++)
        {
            if (_emty_line[y] == _y)
                return true;
        }
        return false;
    }
    private int[] MyCheckEmptyLine()
    {
        List<int> arr = new List<int>();

        for (int ind = 0; ind < hei; ind++)
        {
            int count_line_x = 0;

            for (int x = 0; x < wid; x++)
            {
                if (my_array[x, ind].get_isActive_tetrino())
                    break;
                else
                    count_line_x++;
            }
            if (count_line_x == wid)
                arr.Add(ind);
        }
        return arr.ToArray();
    }
    private int[] MyCheckFullLine()
    {
        List<int> arr = new List<int>();

        for (int ind = 0; ind < hei; ind++)
        {
            int count_line_x = 0;

            for (int x = 0; x < wid; x++)
            {
                if (my_array[x, ind].get_isActive_tetrino())
                    count_line_x++;
                else
                    break;
            }

            if (count_line_x == wid)
                arr.Add(ind);
        }
        return arr.ToArray();
    }
    // Метод Update вызывается каждый кадр
    private void Update()
    {
        if (my_figure)
        {
            if (Input.GetButtonDown("RotateTetrino"))
            {
                my_figure.GetComponentInChildren<my_tetrino_data>().MyRotation(true);
                if (CheckIntersect(my_figure))
                    my_figure.GetComponentInChildren<my_tetrino_data>().MyRotation(false);
            }

            if (Input.GetButtonDown("LeftTetrino"))
            {
                my_curr_time = 0;
                my_figure.MySetDirection(MyDirectionTetrino.LEFT);
                if (CheckIntersect(my_figure))
                    my_figure.MySetDirection(MyDirectionTetrino.RIGHT);
            }

            else if (Input.GetButtonDown("RightTetrino"))
            {
                my_curr_time = 0;
                my_figure.MySetDirection(MyDirectionTetrino.RIGHT);
                if (CheckIntersect(my_figure))
                    my_figure.MySetDirection(MyDirectionTetrino.LEFT);
            }

            else if (Input.GetButton("DownTetrino"))
                MyInputPress(MyDirectionTetrino.DOWN, 0.09f);
            else if (Input.GetButton("RightTetrino"))
                MyInputPress(MyDirectionTetrino.RIGHT, 0.2f);
            else if (Input.GetButton("LeftTetrino"))
                MyInputPress(MyDirectionTetrino.LEFT, 0.2f);
        }
    }
    private void MyInputPress(MyDirectionTetrino _dir, float _time)
    {
        my_curr_time += Time.deltaTime;
        if (my_curr_time > _time)
        {
            my_curr_time = 0;

            if (_dir == MyDirectionTetrino.LEFT)
            {
                my_figure.MySetDirection(MyDirectionTetrino.LEFT);
                if (CheckIntersect(my_figure))
                    my_figure.MySetDirection(MyDirectionTetrino.RIGHT);
            }

            else if (_dir == MyDirectionTetrino.RIGHT)
            {
                my_figure.MySetDirection(MyDirectionTetrino.RIGHT);
                if (CheckIntersect(my_figure))
                    my_figure.MySetDirection(MyDirectionTetrino.LEFT);
            }
            else if (_dir == MyDirectionTetrino.DOWN)
            {
                my_figure.MyDropTetrino(true);
                if (CheckIntersect(my_figure))
                    my_figure.MyDropTetrino(false);
            }
        }
    }
    private bool CheckIntersect(my_tetrino_figure _figure)
    {
        for (int ind = 0; ind < _figure.GetSegments().Length; ind++)
        {
            int x = (int)_figure.GetSegments()[ind].transform.position.x;
            int y = (int)_figure.GetSegments()[ind].transform.position.y;

            bool is_intersect = IsIntersect(x, y);

            if (is_intersect)
                return is_intersect;
        }
        return false;
    }
    private bool CheckPreIntersect(my_tetrino_figure _figure)
    {
        for (int ind = 0; ind < _figure.GetSegments().Length; ind++)
        {
            int x = (int)_figure.GetSegments()[ind].transform.position.x;
            int y = (int)_figure.GetSegments()[ind].transform.position.y;

            bool is_intersect = IsIntersect(x, y);

            if (is_intersect)
            {   
                _figure.MyDropTetrino(false);
                return is_intersect;
            }   
        }
        return false;
    }
    private bool IsIntersect(int _x, int _y)
    {
        try
        {
            if (my_array[_x, _y].get_isActive_tetrino())
                return true;
        }
        catch (System.Exception ex) { return true; }
        return false;
    }
}