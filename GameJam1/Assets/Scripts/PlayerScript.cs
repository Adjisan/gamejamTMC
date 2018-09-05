using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int jumpLimit;

    private Rigidbody2D rb;
    public LineRenderer lr;
    public SpringJoint2D spring;
    public Rigidbody2D bungyAncor;
    public bool clickedPlayer;
    public Vector2 previousVelocity;
    public bool shot = false;
    public bool go = false;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shot == true)
        {
            Release();
        }
        else
        {

        }
        previousVelocity = rb.velocity;

        if (go == true && jumpLimit > 0)
        {
            Fire();
            go = false;
            
        }
        lr.SetPosition(0, transform.position);
        if(spring.enabled == true)
        {
            lr.enabled = true;
            lr.SetPosition(1, spring.connectedBody.transform.position);
        }
        else
        {
            lr.enabled = false;
        }
        if (jumpLimit <= 0) {
            StartCoroutine(Restart());
        }

    }

    IEnumerator Restart() {
        yield return new WaitForSeconds(2.5f); ///specify time needed
                                               ///ToDo: add wat to next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Fire()
    {
        spring.distance = Vector2.Distance(spring.connectedBody.transform.position,transform.position)/3;
        spring.enabled = true;
        rb.isKinematic = false;
        shot = true;
        jumpLimit--;
        
    }

    public void Release()
    {
        
        //if bird starts to slow down(due to spring pulling back) disable spring
        if (previousVelocity.magnitude > rb.velocity.magnitude)
        {
            shot = false;
            spring.enabled = false;
        }
    }
    
    public void Recharge(int i)
    {
        jumpLimit += i;
    }
}
