using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackjack : MonoBehaviour
{

    public static string[] suites = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCards()
    {
        deck = GenerateDeck();

        foreach (string card in deck)
        {
            print(card);
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
}
