using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCard : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardback;
    public int cardValue;
    private SpriteRenderer spriteRenderer;
    private Blackjack blackjack;

    private void Awake()
    {
        blackjack = FindObjectOfType<Blackjack>();

    }
    // Start is called before the first frame update
    void Start()
    {
        CalculateCard();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void CalculateCard()
    {
        List<string> deck = Blackjack.GenerateDeck();
        int i = 0;
        foreach (var card in deck)
        {
            if (this.name == card)
            {
                cardFace = blackjack.cardFaces[i];
                break;
            }
            i++;
        }
        cardValue = (i % 13) + 1;
        if (cardValue > 10)
            cardValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = cardFace;
    }
}
