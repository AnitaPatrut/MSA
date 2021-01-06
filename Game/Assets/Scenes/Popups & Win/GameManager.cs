using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;
    public GameObject completeLevelUI;


    public void CompleteLevel()
    {
        Time.timeScale = 0;
        completeLevelUI.SetActive(true);
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvl()
    {
        string name_current_scene = SceneManager.GetActiveScene().name;
        string level_no = name_current_scene.Substring(name_current_scene.IndexOf("Level ") + "Level ".Length);
        int val = Int16.Parse(level_no) + 1;
        //Debug.Log(val);
        Time.timeScale = 1;
        if(val == 3)
            SceneManager.LoadScene("Menu 1");
        else
            SceneManager.LoadScene("Level " + val);
    }

    public void returnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu 1");
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            Invoke("Restart", restartDelay);
        }
    }

    
}
