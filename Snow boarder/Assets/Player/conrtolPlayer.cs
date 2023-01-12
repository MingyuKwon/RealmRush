using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conrtolPlayer : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rg2d;

    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rg2d.AddTorque(torqueAmount);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            rg2d.AddTorque(-torqueAmount);       
        }
    }
}
