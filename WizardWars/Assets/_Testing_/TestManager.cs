using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {
    public GameObject[] _players;

    public static TestManager _manager;

    public GameObject _testStatus;

    void Awake()
    {
        if(_manager == null)
        {
            //Debug.Log("setting manager");
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
        foreach (var player in _players)
        {
            player.SetActive(true);
        }
        //_testStatus.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
