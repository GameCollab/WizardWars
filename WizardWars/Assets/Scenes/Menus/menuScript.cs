using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Image book;
    public Button startText;
    public Button exitText;
    public Button playButton;
    public Button deckButton;
    public Button optionsButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        startText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //*****************BUTTON SCRIPTS*****************
    public void playClick()
    {

    }

    public void deckClick ()
    {
        book.GetComponent<Animator>().SetTrigger("buttonClicked");
        hideButtons();
    }

    public void optionsClick ()
    {
        book.GetComponent<Animator>().SetTrigger("buttonClicked");
        hideButtons();
    }

    public void exitClick ()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void noClick ()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
	
    public void startLevel ()
    {

    }

    public void exit ()
    {
        Debug.Log("HELLO");
        Application.Quit();
    }
    //************************************************

    private void hideButtons ()
    {
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        deckButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
