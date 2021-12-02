using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStuff : MonoBehaviour
{
    public IventoryHandler IventoryScript;
    /*public void LoadScene(string name)
    {
        //SceneManager.LoadScene(name);


    }*/

    public void Play()
    {
        IventoryScript.MenuOpen = false;
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting!!!!");
    }

}
