using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {
    public uint _id;

    public static uint _nextID = 0;
	// Use this for initialization
	void Start () {
        _nextID++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
