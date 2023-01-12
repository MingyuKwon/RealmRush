using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints =5;
    
    [Tooltip("Add amount to maxHitPoint when enemy dies")]
    [SerializeField] int difficultyRamp =1;
    [SerializeField] int currentHitPoint = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }
    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoint--;
        if(currentHitPoint<1)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
        }
    }
}
