using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Account {

    string accountName;
    string password;
    List<Card> collection;
    List<Deck> decks;
    string preferences;

    public Account (string _n)
    {
        collection = new List<Card>();
        decks = new List<Deck>();
        parseFile();
        accountName = _n;
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
        if (decks.Count >= Max.DECK_LIMIT)
        {
            Debug.Log("Already at deck limit ("+ Max.DECK_LIMIT+ ")");
            return;
        }
        decks.Add(_d);
    }

    /*
        INPUT:
            string _d   name of deck to add card to
            string _c   card to be added
        OUTPUT:
            0 if failure
            1 if success 
    */
    public int addCardToDeck(string _d, string _c)
    {
        return decks.Find(item => item.getName() == _d).addCard(_c);
    }

    public void removeDeck (Deck _d)
    {
        decks.Remove(_d);
    }

    public Deck getDeck(string _d)
    {
        return decks.Find(item => item.getName() == _d);
    }

    public Deck getDeck(int i)
    {
        return decks[i];
    }
}
