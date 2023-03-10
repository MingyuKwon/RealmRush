using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float towerRange = 15f;
    [SerializeField] ParticleSystem arrow;
    Transform target; 
    void Update(){
        FindClosestTarget();
        AimWeapon();
    }
    void AimWeapon(){
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.transform.LookAt(target);
        if(targetDistance <=towerRange )
        {
            Attack(true);
        }else
        {
            Attack(false);
        }
    }
    void FindClosestTarget(){
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
            target = closestTarget;
        }
    }
    void Attack(bool isActive)
    {
        var em = arrow.emission;
        em.enabled = isActive;
    }
}
