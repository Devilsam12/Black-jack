using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public Blackjack blackjack;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayerHit);
    }

    private void PlayerHit()
    {
        blackjack.Deal(blackjack.deck.Last(), blackjack.playerCard, blackjack.playerCards);
    }
}
