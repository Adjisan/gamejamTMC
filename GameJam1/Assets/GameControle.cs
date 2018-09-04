using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControle : MonoBehaviour
{
    public Vector2 pos;
    public GameObject player;
    private PlayerScript psc;
    public Vector2 dif;
    Vector2 bg;
    public Camera cam;
    public GameObject bungy;
    private SpringJoint2D spring;



    // Use this for initialization
    void Start ()
	{
        psc = player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
	    if (Input.GetMouseButtonUp(0))
	    {
	        pos = cam.ScreenToWorldPoint(Input.mousePosition);
            float dis = Vector2.Distance(player.transform.position, pos);
            if(dis > 3)
            {
                dis = 3;
            }
            else if(dis< -3)
            {
                dis = -3;
            }
            dif = new Vector2(pos.x - player.transform.position.x, pos.y - player.transform.position.y);
            dif.Normalize();
            Vector2 playerPos = player.transform.position;
            bg = playerPos + dif * dis;

            if (psc.shot == false)
            {
                CreateBungy();
            }
            
            
        }
    }
    

    void CreateBungy()
    {
        bungy.transform.position = bg;
        Instantiate(bungy);
        Rigidbody2D brb = GameObject.FindGameObjectWithTag("Bungy").GetComponent<Rigidbody2D>();
        psc.spring.connectedBody = brb;
        GameObject.FindGameObjectWithTag("Bungy").tag = "UsedBungy";
        psc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        psc.go = true;

    }
    
}
