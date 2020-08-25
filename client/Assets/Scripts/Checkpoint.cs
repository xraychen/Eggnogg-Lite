using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite tiles_43;
    public Sprite tiles_44;
    public bool checkpointReached;
    private SpriteRenderer checkpointSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "player"){
            checkpointSpriteRenderer.sprite = tiles_44;
            checkpointReached = true;
        }
    }
}
