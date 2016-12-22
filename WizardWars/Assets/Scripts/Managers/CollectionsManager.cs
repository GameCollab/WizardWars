using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constants;

public class CollectionsManager : MonoBehaviour
{

    public Account account;
    public Transform[] deckSlots;
    public GameObject deckPrefab;

    GameObject[] deckButton;

    // Use this for initialization
    void Start()
    {
        string[] testDecks = { "fire", "ice", "heart" };
        deckButton = new GameObject[Max.DECK_LIMIT];
        account = new Account("bob");
        Deck d = new Deck("fire");
        Debug.Log(d);
        account.addDeck(d);
        //account.addDeck(new Deck("ice"));
        //account.addDeck(new Deck("lightning"));
        //accountTest();

        for (int i = 0; i < Max.DECK_LIMIT; i++)
        {
            deckButton[i] = Instantiate(deckPrefab, deckSlots[i].position, deckSlots[i].rotation, deckSlots[i]);
            deckButton[i].GetComponentInChildren<Text>().text = testDecks[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void accountTest()
    {
        account = new Account("bob");
        account.addDeck(new Deck("fire"));
        account.addDeck(new Deck("ice"));
        account.addDeck(new Deck("lightning"));
    }
}
