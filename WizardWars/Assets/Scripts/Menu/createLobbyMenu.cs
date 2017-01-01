using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class createLobbyMenu : MonoBehaviour {

    public Button modeBut;
    public Button createBut;
    public Button backBut;
    public InputField passwordField;
    public InputField gameNameField;

    string gameName;
    string password;
    bool isPrivate;

    /*
        0 -> free for all
        1 -> team
    */
    int mode;

    // Use this for initialization
    void Start () {
        isPrivate = false;
        mode = 0;
	}

    // Update is called once per frame
    void Update()
    {

    }

    /*
        Go back to Main Menu
    */
    public void backClick()
    {
        SceneManager.LoadScene("mainMenu");
    }

    /*
        Create the lobby
    */
    public void createClick()
    {

    }

    /*
        Change game mode
    */
    public void modeClick()
    {
        if (mode == 0)
        {
            mode = 1;
            modeBut.gameObject.GetComponentInChildren<Text>().text = "Free For All";
        }
        else
        {
            mode = 0;
            modeBut.gameObject.GetComponentInChildren<Text>().text = "Teams";
        }
    }

    public void passInput()
    {
        password = passwordField.text;
    }

    public void nameInput()
    {
        gameName = gameNameField.text;
    }
}
