using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck {

    List<Card> cards;
    string name;
    int size;
    bool valid;
    
    public Deck (string _n)
    {
        Debug.Log("Creating Deck " + _n);
        name = _n;
    }

	// Use this for initialization
	void Start () {
        cards = new List<Card>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addCard ()
    {

    }

    void removeCard ()
    {

    }

    void deleteDeck ()
    {

    }

    void changeName ()
    {

    }

    bool isValid ()
    {
        return true;
    }

    public string getName()
    {
        return name;
    }
}
