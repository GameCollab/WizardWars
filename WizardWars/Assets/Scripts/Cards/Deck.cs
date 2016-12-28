using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Deck {

    List<Card> cards;
    string name;
    int size;
    bool valid;

    //use until Card class is finished
    List<string> _cards;

    public Deck (string _n)
    {
        _cards = new List<string>();
        Debug.Log("Creating Deck " + _n);
        name = _n;
    }

    public override string ToString()
    {
        string s = "";
        foreach (string c in _cards)
            s += c + " ";
        return s;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _cards.GetEnumerator();
    }

    public int addCard (string _c)
    {
        if (_cards.Count >= Max.DECK_SIZE)
        {
            Debug.Log("Deck is full");
            return 0;
        }
        _cards.Add(_c);
        return 1;
    }

    public void removeCard (string _c)
    {
        _cards.Remove(_c);
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

    public string getCard(int i)
    {
        if (_cards.Count <= i)
            return "Out of Bounds";
        return _cards[i];
    }

    public string getName()
    {
        return name;
    }
}
