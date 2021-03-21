using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stand : MonoBehaviour
{
    public Blackjack blackjack;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayerStand);
    }

    private void PlayerStand()
    {
        blackjack.playerStand = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
