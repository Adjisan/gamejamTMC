using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Restart());
        }

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.5f); ///specify time needed
        ///ToDo: add wat to next level
    }
}
