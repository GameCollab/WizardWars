﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    /* Main Menu Game Objects */
    public Canvas quitMenu;
    public Image book;
    public Button startText;
    public Button exitText;
    public Button playButton;
    public Button deckButton;
    public Button optionsButton;
    public Button exitButton;
    public GameObject buttonPanel;

    void Start()
    {
        initializeQuitWindow();
    }

    void Update()
    {

    }

    //*****************MAIN MENU BUTTONS*****************

    /*
        User clicks play button
    */
    public void playClick()
    {

    }

    /*
        User clicks deck button
    */
    public void deckClick()
    {
        SceneManager.LoadScene("deckMenu");
    }

    /*
        User clicks options button
    */
    public void optionsClick()
    {
        book.GetComponent<Animator>().SetTrigger("buttonClicked");
        hideButtonPanel();
    }

    /*
        Show the quit window when user clicks exit
    */
    public void exitClick()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    /*
        User clicks NO in the quit window
    */
    public void noClick()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void startLevel()
    {

    }

    /*
        User Clicks YES in the quit window
    */
    public void exit()
    {
        Debug.Log("HELLO");
        Application.Quit();
    }
    //**************************************************

    /*
        Hide the buttons when playing page turn animation
    */
    private void hideButtonPanel()
    {
        buttonPanel.GetComponent<CanvasGroup>().alpha = 0;
        buttonPanel.GetComponent<CanvasGroup>().interactable = false;
    }

    /*
        Quit window is the window that pops up when the user clicks the quit button
    */
    private void initializeQuitWindow()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }
}