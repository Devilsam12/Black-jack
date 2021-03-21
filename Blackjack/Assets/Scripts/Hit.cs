using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
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
        StartCoroutine(PlayRound());
    }

    private IEnumerator PlayRound()
    {
        if (!blackjack.playerStand)
        {
            blackjack.Deal(blackjack.deck.Last(), blackjack.playerCard, blackjack.playerCards);

        }
        if (blackjack.canDealerHit)
        {
            yield return new WaitForSeconds(1.5f);
            blackjack.Deal(blackjack.deck.Last(), blackjack.dealerCard, blackjack.dealerCards);
        }
    }
}
