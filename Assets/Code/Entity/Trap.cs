using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Trap : Entity {

    SpriteRenderer spriteRenderer;
    [SerializeField]
    private List<Sprite> availableSprites;
  

	// Use this for initialization
	public override void Start ()
    {
    
        base.Start();
        
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = availableSprites[Random.Range(0,availableSprites.Count)];
	}
	
	// Update is called once per frame
	public override void Update () 
    {
    
        base.Update();
        
        moveEntity();
	}

    public override void moveEntity()
    {

        base.moveEntity();

        this.entitySpeed = 0.09f;
    }
}
