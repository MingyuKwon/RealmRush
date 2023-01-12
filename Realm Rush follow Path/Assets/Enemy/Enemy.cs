using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int glodReward = 25;
    [SerializeField] int glodPenalty = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if(bank == null)
        {
            return;
        }
        bank.Deposit(glodReward);
    }

    public void StealGold()
    {
        if(bank == null)
        {
            return;
        }
        bank.Withdrawal(glodPenalty);
    }

}
