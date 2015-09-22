using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class chunkSpriteSelector : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    [SerializeField]
    private List<Sprite> availableSprites;


	// Use this for initialization
	void Start () {

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = availableSprites[Random.Range(0, availableSprites.Count)];
	}
	
	// Update is called once per frame
	void Update () {}
}
