using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour 

{
    [SerializeField] int startingBalance = 500;
    [SerializeField] int currentBalace;
    public int CurrentBalace{ get {return currentBalace;} }

    ShowBalance UI;

    private void Awake() {
        currentBalace = startingBalance;
        UI = FindObjectOfType<ShowBalance>();
    }
    public void Deposit(int amount)
    {
        currentBalace += Mathf.Abs(amount); 
        UI.ChangeBalance();
        // either amount is -, handle +
    }

    public void Withdrawal(int amount)
    {
        currentBalace -= Mathf.Abs(amount); 
        UI.ChangeBalance();
        if(currentBalace < 0)
        {
            ReloadScene();
        }
        // either amount is +, handle -
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
