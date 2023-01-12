using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0,218,255,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage  = false;
    SpriteRenderer spriteRenderer;

    Driver driver;
    ui UI;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
        driver = FindObjectOfType<Driver>();
        UI = FindObjectOfType<ui>();
    }
     void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("OnCollisionEnter2D");
        driver.Stun();
    }

     void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject);
            hasPackage = true;
        }

        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            UI.ChangeGuestCount();
            Destroy(other.gameObject);
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
        if(other.tag == "Booster")
        {
            Debug.Log("Gonna go fast!");
            Destroy(other.gameObject);
            driver.Boost = driver.Boost + 1;
            UI.changeBoost(driver.Boost);
        }
    }
}
