using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField][Range(0.1f , 30f)] float spawnTimeDelay = 1f;
    [SerializeField][Range(0 , 50)] int poolSize = 5;
    [SerializeField] GameObject enemyPrefab;
    GameObject[] pool;
    private void Awake() {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }
    IEnumerator CreateEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimeDelay);
        }
 
    }
    void EnableObjectInPool()
    {
        foreach(GameObject poolElement in pool)
        {
            if(poolElement.activeInHierarchy == false)
            {
                poolElement.SetActive(true);
                return;
            }
        }
    }
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i=0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
}
