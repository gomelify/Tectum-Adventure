using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public string m_LevelName;

    public void NewGame()
    {
        Application.LoadLevel(m_LevelName);
    }

    public void LoadGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
