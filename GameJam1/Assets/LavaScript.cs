using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    public GameObject particle;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player"){
            particle.transform.position = this.transform.position;
            Instantiate(particle);
            StopAllCoroutines();
            StartCoroutine(Restart());
        }
        
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.5f);
        ///ToDo: add restart for level
    }
}
