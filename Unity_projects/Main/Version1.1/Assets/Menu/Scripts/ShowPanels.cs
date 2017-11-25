﻿using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour
{
    public GameObject optionsTint; //Store a reference to the Game Object OptionsTint 

    public GameObject rulesPanel;
    public GameObject optionsPanel; //Store a reference to the Game Object OptionsPanel 
    public GameObject highscorePanel;
    public GameObject creditsPanel;
    public GameObject menuPanel; //Store a reference to the Game Object MenuPanel 
    public GameObject pausePanel; //Store a reference to the Game Object PausePanel 


    // === show functions ===

    public void ShowRulesPanel()
    {
        rulesPanel.SetActive(true);
        optionsTint.SetActive(true);
    }
    
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
        optionsTint.SetActive(true);
    }
    
    public void ShowHighscorePanel()
    {
        highscorePanel.SetActive(true);
        optionsTint.SetActive(true);
    }
    
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        optionsTint.SetActive(true);
    }


    // === hide functions ===

    public void HideRulesPanel()
    {
        rulesPanel.SetActive(false);
        rulesPanel.SetActive(false);
    }
    
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
        optionsTint.SetActive(false);
    }
    
    public void HideHighscorePanel()
    {
        highscorePanel.SetActive(false);
        optionsTint.SetActive(false);
    }
    
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        optionsTint.SetActive(false);
    }
}