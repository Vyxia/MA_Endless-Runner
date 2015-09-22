using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : Entity {

    private GameObject firstChunk;
    private MapGenerator mapper;
    private bool allowMovement = true;
    private bool dead = false;


	public override void Start () 
    {

        base.Start();

        mapper = GameObject.Find("ChunkManager").GetComponent<MapGenerator>();
        firstChunk = mapper.getFirstChunk;
        this.gameObject.transform.position = new Vector3(firstChunk.transform.position.x,firstChunk.transform.position.y+0.8f,-3);
	}
	
	// Update is called once per frame
	public override void Update () 
    {

        if (allowMovement == true)
        {
            moveEntity();
        }
	}

    public override void moveEntity()
    {

        if (this.gameObject.transform.position.y <= -Camera.main.orthographicSize + this.gameObject.GetComponent<BoxCollider2D>().size.y && allowMovement == true)
        {
            allowMovement = false;
        }
        else
        {
            
            this.gameObject.transform.position += new Vector3(0, -0.09f);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "trap")
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(this.gameObject);
        Destroy(this);
        dead = true;
    }

    public bool hasDied
    {

        get
        {
            return dead;
        }
    }
}
