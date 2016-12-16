using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
    attributes _attributes;

	// Use this for initialization
	void Start () {
        unitTest();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //testing Stuff
    void unitTest() {
        _attributes["curLife"] = 99;
        Debug.Log(_attributes["curLife"]);
    }
}
