using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ScriptForMenu : MonoBehaviour
{
    private bool _Paused = false;
    public GameObject Panel;
    public void Pause()
    {
        PanelUse();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelUse();
        }
    }
    void PanelUse()
    {
        if (!_Paused)
            {
                Time.timeScale = 0;
                _Paused = true;
                Panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                _Paused = false;
                Panel.SetActive(false);
            }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
