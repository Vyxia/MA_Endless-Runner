using UnityEngine;
using System.Collections;

public class Enemy : Entity {

    private bool allowMovement = true;
    private Animator animController;
    private Animation attackAnimation;
    private bool hasAttacked = false;
    [SerializeField]
    private GameObject fireBall;

	// Use this for initialization
	public override void Start () 
    {
   
        base.Start();

        animController = this.gameObject.GetComponent<Animator>();
        animController.SetBool("Attack", false);
	}
	
	// Update is called once per frame
	public override void Update () 
    {

        base.Update();

        moveEntity();
        if (this.transform.position.y <= Camera.main.orthographicSize - this.gameObject.GetComponent<BoxCollider2D>().size.y)
        {
            castSpell();
        }
	}

    void castSpell()
    {

        if (hasAttacked == false)
        {
            animController.SetBool("Attack", true);
            allowMovement = false;
            hasAttacked = true;
            Instantiate(fireBall, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,this.transform.position.z-1), Quaternion.identity);
        }
    }

    public override void moveEntity()
    {

        if (allowMovement == true)
        {
            this.transform.position += new Vector3(0, -0.09f);
        }
    }   
}
