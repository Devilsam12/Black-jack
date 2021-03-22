using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stand : MonoBehaviour
{
    public Blackjack blackjack;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayerStand);
    }

    private void PlayerStand()
    {
        blackjack.playerStand = true;
        StartCoroutine(blackjack.PlayAsDealer());
    }

    // Update is called once per frame
    void Update()
    {
        if (blackjack.isResetEnabled)
            btn.interactable = false;
        else
            btn.interactable = true;
    }
}
