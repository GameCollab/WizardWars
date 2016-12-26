using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int _playerNumber;
    public Attributes _attributes;
	// Use this for initialization
	void Start () {
        _attributes = new Attributes();
        _attributes.Health = 100f;
        _attributes.Speed = 3f;
	}
	
    
}
