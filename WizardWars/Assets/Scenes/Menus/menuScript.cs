using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        startText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void exitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void noPress()
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

	// Update is called once per frame
	void Update () {
		
	}
}
