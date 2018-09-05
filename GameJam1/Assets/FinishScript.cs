using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("NEXT LEVEL");
            StopAllCoroutines();
            StartCoroutine(Restart());
        }

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f); ///specify time needed
                                               ///ToDo: add wat to next level
        if (SceneManager.GetActiveScene().buildIndex + 1 > 4) {
            SceneManager.LoadScene("level1");
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
