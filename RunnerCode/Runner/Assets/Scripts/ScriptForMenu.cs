using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ScriptForMenu : MonoBehaviour
{
    private bool _Paused = false,_Market = false;
    public GameObject Panel, MarketPanel;
    private Text _CoinScore;
    private Text _BestScore;
    public void Pause()
    {
        PanelUse();
    }

    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Loading();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            PanelUse();
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            _CoinScore = GameObject.Find("CoinsScore").GetComponent<Text>();
            _CoinScore.text = PlayerPrefs.GetInt("CoinsScore").ToString();
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
        Time.timeScale = 1;
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
    public void Loading()
    {
        _CoinScore = GameObject.Find("CoinsScore").GetComponent<Text>();
        _CoinScore.text = PlayerPrefs.GetInt("CoinsScore").ToString();

        _BestScore = GameObject.Find("BestScore").GetComponent<Text>();
        _BestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore").ToString(); 
    }

    public void Market()
    {
        if(!_Market)
        {
            MarketPanel.SetActive(true);
            _Market = true;
        }
        else
        {
            MarketPanel.SetActive(false);
            _Market = false;
        }
        
    }


}
