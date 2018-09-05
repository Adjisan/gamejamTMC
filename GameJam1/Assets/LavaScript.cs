using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour {

    public GameObject particle;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player"){
            
            if (particle != null) {
                particle.transform.position = collider.transform.position;
                Instantiate(particle);
            }
            GameObject.Destroy(collider.gameObject);
            StopAllCoroutines();
            StartCoroutine(Restart());
        }
        
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.5f);
        ///ToDo: add restart for level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
