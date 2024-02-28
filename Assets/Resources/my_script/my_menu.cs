using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class my_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
    public void Record()
    {
        SceneManager.LoadScene("Record");
    }
    public void Button()
    {
        SceneManager.LoadScene("Menu");
    }
}
