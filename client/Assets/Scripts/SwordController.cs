using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "player"){
            //what will happen when the sword hit the player
            //Debug.Log("Hit!!");
            // gameLevelManager.Respawn2(other.gameObject.GetInstanceID());
        }
        if(other.tag == "bodycontainer"){
            //what will happen when the sword hit the player's container
            //Debug.Log("Body Hit!!!!!");
            // gameLevelManager.Respawn2(other.gameObject.transform.parent.gameObject.GetInstanceID());
        }
    }
}
