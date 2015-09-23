using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class chunkSpriteSelector : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField]
    private List<Sprite> availableSprites;

    void Start()
    {

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = availableSprites[Random.Range(0, availableSprites.Count)];
    }
}
