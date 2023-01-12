using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject waypoint = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in waypoint.transform)
         {
            WayPoint wp = child.GetComponent<WayPoint>();
            if(wp != null)
                path.Add(wp);
         }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(WayPoint waypoint in path )
            {
                Vector3 startPosition  = transform.position;
                Vector3 endPosition  = waypoint.transform.position;
                float travelPercent = 0f;

                transform.LookAt(endPosition);

                while(travelPercent < 1f){
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
                
            }
            FinishPath();
    }
}


