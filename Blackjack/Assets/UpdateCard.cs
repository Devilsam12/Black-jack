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
    
    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Blackjack.GenerateDeck();
        blackjack = FindObjectOfType<Blackjack>();

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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = cardFace;
    }
}
