using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Blackjack : MonoBehaviour
{
    public Sprite[] cardFaces;
    public static string[] suites = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    [SerializeField] GameObject cardPrefab;
    public List<string> deck;
    [SerializeField] float xOffset = 0.5f;
    [SerializeField] float zOffset = 0.1f;
    public Transform playerCard;
    public Transform dealerCard;

    public bool canDealerHit = true;
    public bool playerStand = false;

    public int playerTotal = 0;
    public int dealerTotal = 0;

    [SerializeField] Text playerText;
    [SerializeField] Text dealerText;


    public List<GameObject> playerCards = new List<GameObject>();
    public List<GameObject> dealerCards = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
    }

    private void TextUpdate()
    {
        playerText.text = "Player : " + playerTotal;
        dealerText.text = "Dealer : " + dealerTotal;
    }

    void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        /*Deal(deck.Last(), playerCard, playerCards);
        Deal(deck.Last(), dealerCard, dealerCards);
        Deal(deck.Last(), dealerCard, dealerCards);
        Deal(deck.Last(), dealerCard, dealerCards);
        Deal(deck.Last(), playerCard, playerCards);*/


    }

    public void Deal(string cardname, Transform cardPos, List<GameObject> cardList)
    {
        int count = cardList.Count();
        GameObject newCard = Instantiate(cardPrefab, new Vector3(cardPos.position.x + (xOffset * count), cardPos.position.y, cardPos.position.z - (zOffset * count)), Quaternion.identity, playerCard);
        newCard.name = cardname;
        cardList.Add(newCard);
        deck.RemoveAt(deck.Count - 1);
        StartCoroutine(UpdateTotal(cardPos, cardList));
    }

    private IEnumerator UpdateTotal(Transform cardPos, List<GameObject> cardList)
    {
        yield return new WaitForEndOfFrame();
        int total = 0;

        foreach(var card in cardList)
        {
            total += card.GetComponent<UpdateCard>().cardValue;
        }
        if (cardPos == playerCard)
            playerTotal = total;
        else
        {
            dealerTotal = total;
            if (total >= 17)
                canDealerHit = false;
        }
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach(string suite in suites)
        {
            foreach(string value in values)
            {
                newDeck.Add(suite + value);
            }
        }

        return newDeck;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
