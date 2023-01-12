using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fail : MonoBehaviour
{
  [SerializeField] ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Ground")
        Instantiate(ps, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        Invoke("ReloadScene", 0.5f);
      }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
