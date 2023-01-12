using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finishLine : MonoBehaviour
{
   [SerializeField] ParticleSystem ps;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
          Instantiate(ps, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
          Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
