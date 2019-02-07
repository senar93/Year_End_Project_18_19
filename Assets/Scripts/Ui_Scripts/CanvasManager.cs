﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour
{

    [Tooltip("Schermata di pausa")]
    public GameObject PauseScreen;
    [Tooltip("Pulsante di resume per selezione all'apertura della schermata")]
    public GameObject ResumeButton;//Holds the first selected item
    public static bool isPaused = false;

    [Tooltip("Schermata dell'invetario")]
    public GameObject InvenvotryScreen;
    [Tooltip("Pulsante desiderato come selezionato all'apertura della schermata")]
    public GameObject FirstInventory;//Holds the first selected item
    public static bool isOpenInventory = false;

    [Tooltip("Schermata InPlay")]
    public GameObject InPlayScreen;

    public List<GameObject> LifePoints;

    private EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_EventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && !isPaused && isOpenInventory == false)
        {
            PauseGame();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && isPaused)
        {
            UnpauseGame();
        }
        
        if (Input.GetButtonDown("Inventory") && !isOpenInventory && isPaused == false)
        {
            OpenInventory();
        }
        else if (Input.GetButtonDown("Inventory") && isOpenInventory)
        {
            CloseInventory();
        }
    }

    /// <summary>
    /// Apre la schermata di pausa e setta la timescale a 0
    /// </summary>
    public void PauseGame() {
        isPaused = !isPaused;
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        m_EventSystem.SetSelectedGameObject(ResumeButton); //Set selection to the first button in the pause screen
    }

    /// <summary>
    /// Chiude la schermata di pausa e setta la timescale a 1
    /// </summary>
    public void UnpauseGame() {
        isPaused = !isPaused;
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        m_EventSystem.SetSelectedGameObject(null);
    }

    /// <summary>
    /// Apre la schermata di invetario
    /// </summary>
    public void OpenInventory()
    {
        Time.timeScale = 0f;
        isOpenInventory = !isOpenInventory;
        InPlayScreen.SetActive(false);//deactivate/activate the inplay screen
        InvenvotryScreen.SetActive(true);
        m_EventSystem.SetSelectedGameObject(FirstInventory); //Set selection to the first button in the inventory screen
    }

    /// <summary>
    /// Chiude la schermata di invetario
    /// </summary>
    public void CloseInventory()
    {
        Time.timeScale = 1f;
        isOpenInventory = !isOpenInventory;
        InPlayScreen.SetActive(true);//deactivate/activate the inplay screen
        InvenvotryScreen.SetActive(false);
        m_EventSystem.SetSelectedGameObject(null); //Set selection to the first button in the inventory screen
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateLifeBar(int currentLife)
    {
        ResetLifeBar();

        for (int i = 0; i < currentLife; i++)
        {
            LifePoints[i].SetActive(true);
        }
    }

    private void ResetLifeBar()
    {
        foreach (GameObject lifePoint in LifePoints)
        {
            lifePoint.SetActive(false);
        }
    }
}
