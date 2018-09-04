using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControle : MonoBehaviour
{
    public Vector2 pos;
    public GameObject player;
    private Rigidbody2D rb;
    private PlayerScript psc;
    public Vector2 dif;
    public Camera cam;

	// Use this for initialization
	void Start ()
	{
        rb = player.GetComponent<Rigidbody2D>();
        psc = player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
	    if (Input.GetMouseButtonUp(0))
	    {
	        pos = cam.ScreenToWorldPoint(Input.mousePosition);
            CalculateBungy();
        }
    }

    void CalculateBungy()
    {
        
            dif.x = pos.x - player.transform.position.x;
        
        
            dif.y = pos.y - player.transform.position.y;
        
        float difer = Vector2.Distance(player.transform.position, pos);
        if(difer > 4)
        {
            difer = 5;
        }
        dif.Normalize();
        dif *= difer;
        
        rb.AddForce(dif * 50);
        

    }
}
