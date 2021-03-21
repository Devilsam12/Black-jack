using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blackjack : MonoBehaviour
{
    public Sprite[] cardFaces;
    public static string[] suites = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    [SerializeField] GameObject cardPrefab;
    List<string> deck;
    [SerializeField] float xOffset = 0.1f;
    [SerializeField] float zOffset = 0.1f;
    [SerializeField] Transform playerCard;
    [SerializeField] Transform dealerCard;


    List<GameObject> playerCards = new List<GameObject>();
    List<GameObject> dealerCards = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        Deal(deck.Last(), playerCard, playerCards);
        Deal(deck.Last(), dealerCard, dealerCards);

    }

    private void Deal(string cardname, Transform cardPos, List<GameObject> cardList)
    {
        GameObject newCard = Instantiate(cardPrefab, cardPos.position, Quaternion.identity, playerCard);
        newCard.name = cardname;
        cardList.Add(newCard);
        deck.RemoveAt(deck.Count - 1);
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
