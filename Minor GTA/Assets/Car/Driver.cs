using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float boostSpeed = 45f;
    [SerializeField] float steerSpeed = 5f;

    [SerializeField] float stunTime = 1f;

    [SerializeField] int boost = 0;

    [SerializeField] bool boostFlag = false;
    [SerializeField] bool stunFlag = false;

    ui UI;
    public float MoveSpeed{
        get{
            return moveSpeed;
        }
    }
    public bool Boostflag{
        get{
            return boostFlag;
        }

        set{
            boostFlag = value;
        }
    }

    public int Boost{
        get{
            return boost;
        }

        set{
            boost = value;
        }
    }

    float steerInput;
    float moveInput;

    private void Start() {
     UI = FindObjectOfType<ui>();
    }
    void Update()
    {
        if(!stunFlag)
        {
            steerInput = Input.GetAxis("Horizontal");
            moveInput = Input.GetAxis("Vertical");
            if(!boostFlag)
            {
                transform.Translate(0, moveInput * moveSpeed * Time.deltaTime, 0 );
            }
            transform.Rotate(0,0,-1 * steerInput * steerSpeed * Time.deltaTime);
        
            if(Input.GetKeyDown(KeyCode.Space) && !boostFlag && (boost > 0) )
            {
                boost--;
                UI.changeBoost(boost);
                GoFast();
            }
        }
        
    }

    void GoFast()
    {
        Debug.Log("start boost");
        StartCoroutine(Boosting());
        
    }
    public void Stun()
    {
        StartCoroutine(Stunning());
    }
    IEnumerator Stunning()
    {
        float time = 0f;
        stunFlag = true;
        while(time < stunTime)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        stunFlag = false;
    }

    IEnumerator Boosting()
    {
        boostFlag = true;
        float boostPercent = 0f;
        float firstSpeed = moveSpeed;
        float endSpeed = boostSpeed;

        while( boostPercent < 1f )
        {
            boostPercent +=  Time.deltaTime * 4f;
            moveSpeed = firstSpeed + (endSpeed - firstSpeed) * boostPercent;
            transform.Translate(0, moveSpeed * Time.deltaTime,0 );
            yield return new WaitForEndOfFrame();
        }

        float time = 0f;
        while(time < 1f)
        {
            time += Time.deltaTime;
            transform.Translate(0, moveSpeed * Time.deltaTime,0);
            yield return new WaitForEndOfFrame();
        }

        while( boostPercent > 0f )
        {
            boostPercent -=  Time.deltaTime * 4f;
            moveSpeed = firstSpeed + (endSpeed - firstSpeed) * boostPercent;
            transform.Translate(0, moveSpeed * Time.deltaTime,0 );
            yield return new WaitForEndOfFrame();
        }
        boostFlag = false;
    }


}
