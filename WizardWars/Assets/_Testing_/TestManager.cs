using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {
    public GameObject[] _players;

    public static TestManager _manager;

    void Awake()
    {
        if(_manager == null)
        {
            DontDestroyOnLoad(gameObject);
            _manager = this;
        }
        else if(_manager != this)
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        _manager = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
