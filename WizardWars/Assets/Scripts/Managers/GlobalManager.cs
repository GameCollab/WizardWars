using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour, IGlobal {
    /* Instance */
    public static GlobalManager MANAGER;

    /* Core */

    /* References */
    public GameObject[] _statusDatabase;
    public GameObject[] _cardDatabase;
    public GameObject[] _objectDatabase;

    /* Values */
    public GameObject[] _players;

    /* Flags */

    void Awake()
    {
        SetDontDestroyOnLoad();
    }

    void Start ()
    {

    }
	
	void Update ()
    {
		
	}

    public void SetDontDestroyOnLoad()
    {
        if (MANAGER == null)
        {
            DontDestroyOnLoad(gameObject);
            MANAGER = this;
        }
        else if (MANAGER != this)
        {
            Destroy(gameObject);
        }
    }
}
