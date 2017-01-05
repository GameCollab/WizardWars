using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobbyMenu : MonoBehaviour {

    public Transform[] playerBarSlot;
    public GameObject playerBarPrefab;
    public Button create;
    public Button leave;

    GameObject[] playerBar;

	// Use this for initialization
	void Start () {
        playerBar = new GameObject[6];
		
        //display player information for each player
        //fetch player information from global manager
        for (int i = 0; i < 6; i++)
        {
            playerBar[i] = Instantiate(playerBarPrefab, playerBarSlot[i].position, playerBarSlot[i].rotation, playerBarSlot[i]);
            test(i);
            /*
                Set number, name, team number for playerBar[i] based on info from Global Manager
            */
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
        Start the game
    */
    public void createClick()
    {

    }

    /*
        Leave game and go back to menu
    */
    public void backClick()
    {
        SceneManager.LoadScene("mainMenu");
    }

    void test (int i)
    {
        string[] players = { "alice", "bob", "eve", "alex", "joseph", "kevin" };
        playerBar[i].transform.GetChild(0).GetComponent<Text> ().text = players[i];
        playerBar[i].transform.GetChild(1).GetComponent<Text> ().text = i.ToString();
        playerBar[i].transform.GetChild(2).GetComponent<Text> ().text = i.ToString();
    }
}
