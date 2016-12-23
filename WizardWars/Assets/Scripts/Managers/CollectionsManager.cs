using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using UnityEngine.EventSystems;

public class CollectionsManager : MonoBehaviour
{

    public Account account;
    public Image book;
    public GameObject buttonPanel;
    public Transform[] deckSlots;
    public Transform[] cardSlots;
    public GameObject deckPrefab;
    public GameObject cardPrefab;

    GameObject[] deckButton;
    GameObject[] cardButton;

    // Use this for initialization
    void Start()
    {
        deckButton = new GameObject[3];
        cardButton = new GameObject[5];
        accountTest();

        for (int i = 0; i < Max.DECK_LIMIT; i++)
        {
            deckButton[i] = Instantiate(deckPrefab, deckSlots[i].position, deckSlots[i].rotation, deckSlots[i]);
            deckButton[i].GetComponentInChildren<Text>().text = account.getDeck(i).getName();
            Debug.Log(deckButton[i].GetComponent<Button>());
            deckButton[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                deckButtonClick();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
        Navigate to the Collections Page
    */
    public void goToCollectionMenu ()
    {
        book.GetComponent<Animator>().SetTrigger("buttonClicked");
        hideButtonPanel();
        //go to collection page
    }


    /*
        Creates Card Button prefabs  in right page
        for each card in the deck
    */
    public void deckButtonClick ()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        Deck d = account.getDeck(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text> ().text);

        for (int i = 0; i < Max.DECK_SIZE; i++)
        {
            Debug.Log(1);
            cardButton[i] = Instantiate(cardPrefab, cardSlots[i].position, cardSlots[i].rotation, cardSlots[i]);
            Debug.Log(2);
            if (d.getCard(i).Equals("Out of Bounds"))
            {
                Debug.Log(3);
                cardButton[i].GetComponentInChildren<Text>().text = "Empty Slot";
            }
            else
            {
                Debug.Log(4);
                cardButton[i].GetComponentInChildren<Text>().text = d.getCard(i);
            }
            Debug.Log(5);
        }
    }

    /*
        Hides elements in buttonPanel
    */
    private void hideButtonPanel()
    {
        buttonPanel.GetComponent<CanvasGroup>().alpha = 0;
        buttonPanel.GetComponent<CanvasGroup>().interactable = false;
    }

    void accountTest()
    {
        account = new Account("bob");
        account.addDeck(new Deck("fire"));
        account.addDeck(new Deck("ice"));
        account.addDeck(new Deck("lightning"));

        account.addCardToDeck("fire", "fireball");
        account.addCardToDeck("fire", "fireball");
        account.addCardToDeck("fire", "fireball");
        account.addCardToDeck("fire", "fireball");
        account.addCardToDeck("fire", "fireball");

        Debug.Log(account.getDeck("fire"));
    }
}
