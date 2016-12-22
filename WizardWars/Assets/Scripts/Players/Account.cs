using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account {

    string accountName;
    string password;
    List<Card> collection;
    List<Deck> decks;
    string preferences;

    public Account (string _n)
    {
        accountName = _n;
    }

	// Use this for initialization
	void Start () {
        collection = new List<Card> ();
        decks = new List<Deck>();
        parseFile();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //parse *.txt file to fill in information about the account
    void parseFile()
    {

    }

    void addCard ()
    {

    }

    void removeCard ()
    {

    }

    public void addDeck(Deck _d)
    {
        if (_d == null)
        {
            Debug.Log("Deck is null");
            return;
        }
        Debug.Log(_d);
        decks.Add(_d);
    }

    public void removeDeck (Deck _d)
    {
        decks.Remove(_d);
    }

    public Deck getDeck(int i)
    {
        return decks[i];
    }
}
