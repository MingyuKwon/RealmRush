using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    
    public bool CreateTower(Vector3 tilePosition)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false; // for error
        }
        if(bank.CurrentBalace >= cost)
        {
            Instantiate(gameObject, tilePosition, Quaternion.identity);
            bank.Withdrawal(cost);
            return true;
        }
        return false;
        
    }
}
