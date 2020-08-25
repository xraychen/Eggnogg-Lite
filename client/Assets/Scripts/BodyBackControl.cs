using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBackControl : MonoBehaviour
{
    public PlayerController PlayerControllerbody;
    public PlayerManager playermanager;
    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerbody = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
        animator = PlayerControllerbody.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "sword") {
            player = other.gameObject.transform.parent.parent.parent.parent.gameObject;
            playermanager = player.GetComponent<PlayerManager>();
            Debug.Log(player.name);
            Debug.Log("AaronMESSage : back being hit");
            if(player.transform.Find("bodyback").gameObject != gameObject){
                if(playermanager.face_right == PlayerControllerbody.face_right){
                    Debug.Log("Aaron : " + PlayerControllerbody.gameObject.name + " back dead");
                    PlayerControllerbody.trigger_dead();
                }
            }
        }
    }
}
