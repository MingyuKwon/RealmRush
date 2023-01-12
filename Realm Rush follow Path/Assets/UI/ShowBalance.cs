using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowBalance : MonoBehaviour
{
    Bank bank;
    TMP_Text balanceText;
    void Start() {
        balanceText = GetComponent<TMP_Text>();
        bank = FindObjectOfType<Bank>();
        balanceText.text = "Gold : " + bank.CurrentBalace + "";
    }

    public void ChangeBalance(){
        balanceText.text = "Gold : " + bank.CurrentBalace + "";
    }
}
