using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public PlayerController[] gameplayers;
    public PlayerController gameplayer;

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
            gameplayers = FindObjectsOfType<PlayerController> ();
            for(int i = 0; i < gameplayers.Length; i++){
                if(gameplayers[i].gameObject.GetInstanceID() == other.gameObject.GetInstanceID())
                    gameplayer = gameplayers[i];
            }
            Debug.Log("Aaron : player killed by Bomb dead");
            gameplayer.trigger_dead();
        }
        // if(other.tag == "bodycontainer"){
        //     //what will happen when the sword hit the player's container
        //     //Debug.Log("Body Hit!!!!!");
        //     gameLevelManager.Respawn2(other.gameObject.transform.parent.gameObject.GetInstanceID());
        // }
    }
}
