using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ui : MonoBehaviour
{
    TMP_Text guestLeft;
    TMP_Text time;
    TMP_Text speed;
    TMP_Text boost;

    GameObject button;
    TMP_Text cong;
    TMP_Text finaltime;
    


    Driver driver;

    float startTime = Time.time;

    int guest;
    float finalTime;

    void Start() {
        driver = FindObjectOfType<Driver>();
        guest = 8;
        guestLeft = transform.GetChild(0).GetComponent<TMP_Text>();
        time = transform.GetChild(1).GetComponent<TMP_Text>();
        speed = transform.GetChild(2).GetComponent<TMP_Text>();
        boost = transform.GetChild(3).GetComponent<TMP_Text>();
        button = transform.GetChild(4).gameObject;
        cong = transform.GetChild(5).GetComponent<TMP_Text>();
        finaltime = transform.GetChild(6).GetComponent<TMP_Text>();


        guestLeft.text = "guest left : " + guest;
        time.text = "Time :";
        speed.text = "Speed :";
        boost.text = "boost :";

        button.SetActive(false);
        cong.enabled = false;
        finaltime.enabled = false;

    
    }

    void Update() {
        float nowTime = Time.time;
        finalTime = Mathf.Round(nowTime-startTime);
        time.text = "Time : " + finalTime;
        finaltime.text = "Your time : " + finalTime;
        speed.text = "Speed :" + Mathf.Round(driver.MoveSpeed);
    }

    public void ChangeGuestCount()
    {
        guest--;
        guestLeft.text = "guest left :" + guest;

        if(guest < 1)
        {
            ShowResultUI();
        }
    }

    void ShowResultUI()
    {
        driver.Boostflag = true;
        
        button.SetActive(true);
        cong.enabled = true;
        finaltime.enabled = true;
        guestLeft.enabled = false;
        time.enabled = false;
        speed.enabled = false;
        boost.enabled = false;
    }

    public void changeBoost(int b)
    {
        string str = "boost : ";
        
        for(int i=0; i<b; i++)
        {
            str += "O ";
        }
        boost.text = str;
        
    }
}
