using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    private float moveSpeed;
    private float height;

	// Use this for initialization
	public virtual void Start ()
    {
	
        this.height = this.gameObject.GetComponent<BoxCollider2D>().size.y;
	}
	
	// Update is called once per frame
	public virtual void Update () 
    {

        checkBounds();
	}

    public virtual void deathAction()
    {

        Destroy(this.gameObject);
    }

    private void checkBounds()
    {

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            if (screenPosition.y <= height + -(Screen.height))
            {
                deathAction();
            }
    }

   public virtual void moveEntity()
    {

        this.gameObject.transform.position += new Vector3(0, -0.09f);
    }

    public float entitySpeed
    {

       get
       {
           return moveSpeed;
       }
       set
       {
           moveSpeed = value;
       }
    }
}
