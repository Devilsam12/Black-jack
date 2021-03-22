using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public Blackjack blackjack;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetGame);
    }

    private void ResetGame()
    {
        ResetGameState();
        ClearCards();
        blackjack.PlayCards();

    }

    private void ClearCards()
    {
        ClearChildren(blackjack.playerCard);
        ClearChildren(blackjack.dealerCard);
    }

    private void ClearChildren(Transform transform)
    {
        Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);
    }

    private void ResetGameState()
    {
        blackjack.playerCards.Clear();
        blackjack.dealerCards.Clear();
        blackjack.playerTotal = 0;
        blackjack.dealerTotal = 0;
        blackjack.canDealerHit = true;
        blackjack.playerStand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
