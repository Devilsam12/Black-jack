using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public Blackjack blackjack;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayerHit);
    }

    private void PlayerHit()
    {
        StartCoroutine(PlayRound());
    }

    private void Update()
    {
        if (blackjack.isResetEnabled)
            btn.interactable = false;
        else
            btn.interactable = true;
    }

    private IEnumerator PlayRound()
    {
        if (!blackjack.playerStand)
        {
            blackjack.Deal(blackjack.deck.Last(), blackjack.playerCard, blackjack.playerCards);
            yield return new WaitForEndOfFrame();
            blackjack.CheckForEnd();
            if (blackjack.isResetEnabled)
            {
                btn.interactable = false;
                yield break;
            }

        }
        if (blackjack.canDealerHit)
        {
            yield return new WaitForSeconds(1.5f);
            blackjack.Deal(blackjack.deck.Last(), blackjack.dealerCard, blackjack.dealerCards);
            yield return new WaitForEndOfFrame();
            blackjack.CheckForEnd();
            if (blackjack.isResetEnabled)
                btn.interactable = false;
            else
                btn.interactable = true;
        }

    }
}
