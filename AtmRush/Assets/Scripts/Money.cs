using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    public MoneyState currentMoneyState;
    public GameObject dollar;
    public GameObject gold;
    public GameObject diamond;
    public int value = 1;

    public enum MoneyState
    {
        Dollar,
        Gold,
        Diamond
    }

    public void ChangeState(MoneyState newState)
    {
        if (newState == MoneyState.Gold)
        {
            dollar.SetActive(false);
            gold.SetActive(true);
            value = 2;
        }

        else if (newState == MoneyState.Diamond)
        {
            gold.SetActive(false);
            diamond.SetActive(true);
            value = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            bool once = false;

            if (currentMoneyState == MoneyState.Dollar && !once)
            {
                ChangeState(MoneyState.Gold);
                currentMoneyState = MoneyState.Gold;
                once = true;
            }

            else if (currentMoneyState == MoneyState.Gold && !once)
            {
                ChangeState(MoneyState.Diamond);
                currentMoneyState = MoneyState.Diamond;
                once = true;
            }

            CollectedList.instance.ScoreUpdate();
        }

        else if (other.CompareTag("Conveyor"))
        {
            CollectedList.instance.ýnventory.Remove(gameObject);
            transform.DOMoveX(transform.position.x - 10, 1);
            transform.DOMoveZ(transform.position.z , 1);
        }
    }
}
