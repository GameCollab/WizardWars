using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class deckMenu : MonoBehaviour
{
    public Account account;
    public Image book;
    public GameObject buttonPanel;
    public Transform[] deckSlots;
    public Transform[] cardSlots;
    public GameObject deckPrefab;
    public GameObject cardPrefab;
    public Button backButton;

    GameObject[] deckButton;
    GameObject[] cardButton;
    bool deckUp;

    // Use this for initialization
    void Start()
    {
        deckUp = false;
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
    public void goToCollectionMenu()
    {
        book.GetComponent<Animator>().SetTrigger("buttonClicked");
        hideButtonPanel();
        //go to collection page
    }


    /*
        Displays cards and creates Card Buttons in right menu page
    */
    public void deckButtonClick()
    {
        //if cards are being displayed, delete cards
        if (deckUp)
        {
            deleteCardButtons();
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        Deck d = account.getDeck(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);

        for (int i = 0; i < Max.DECK_SIZE; i++)
        {
            cardButton[i] = Instantiate(cardPrefab, cardSlots[i].position, cardSlots[i].rotation, cardSlots[i]);
      
            if (d.getCard(i).Equals("Out of Bounds"))
            {
                cardButton[i].GetComponentInChildren<Text>().text = "Empty Slot";
            }
            else
            {
                cardButton[i].GetComponentInChildren<Text>().text = d.getCard(i);
            }
        }
        deckUp = true;
        
    }

    /*
    User clicks Back button is taken back to main menu
*/
    public void backClick()
    {
        SceneManager.LoadScene("mainMenu");
    }

    /*
        Hides elements in buttonPanel
    */
     void hideButtonPanel()
    {
        buttonPanel.GetComponent<CanvasGroup>().alpha = 0;
        buttonPanel.GetComponent<CanvasGroup>().interactable = false;
    }

    /*
        Removes the card buttons in right menu page
    */
    void deleteCardButtons()
    {
        foreach (GameObject card in cardButton)
        {
            if (card != null)
            { 
                Destroy(card);
            }
        }
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