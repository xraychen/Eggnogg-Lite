using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMiddleControl : MonoBehaviour
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
        //Debug.Log("PlayerControllerbody.gameObject.name");
        //Debug.Log(PlayerControllerbody.gameObject.name);
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
            Debug.Log("AaronMESSage : middle being hit");
            if(player.transform.Find("bodymiddle").gameObject != gameObject){
                if(playermanager.face_right != PlayerControllerbody.face_right){
                    bool is_up = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle");
                    bool is_run = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run");
                    bool is_up_attack = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Attack");
                    bool is_run_attack = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Attack");
                    Debug.Log(is_up);
                    Debug.Log(is_run);
                    Debug.Log(is_up_attack);
                    Debug.Log(is_run_attack);
                    if(!is_up && !is_up_attack && !is_run && !is_run_attack){
                        Debug.Log("AaronCheck");
                        Debug.Log("Aaron : " + PlayerControllerbody.gameObject.name + " middle dead 1");
                        PlayerControllerbody.trigger_dead();
                    }
                }
                else{
                    Debug.Log("AaronCheck");
                    Debug.Log("Aaron : " + PlayerControllerbody.gameObject.name + " middle dead 2");
                    PlayerControllerbody.trigger_dead();
                }
            }
        }
    }
}
