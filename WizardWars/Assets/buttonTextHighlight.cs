using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTextHighlight : MonoBehaviour {

    private Button but;

	// Use this for initialization
	void Start () {
        but = this.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        but.GetComponentInChildren<Text>().color = but.targetGraphic.canvasRenderer.GetColor();
	}
}
