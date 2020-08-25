using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalldetectorControl : MonoBehaviour
{
    public GameObject DeadBodyPrefab;

    public LevelManager gameLevelManager;
    private Rigidbody2D rb;
	private Animator animator;
	public PlayerController[] gameplayers;
    public PlayerController gameplayer;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager> ();
        gameplayers = FindObjectsOfType<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "player"){
            //what will happen when the sword hit the player
            //Debug.Log("Hit!!");
            Debug.Log("Aaron : player detected by fall detector");
			gameplayers = FindObjectsOfType<PlayerController> ();
			for(int i = 0; i < gameplayers.Length; i++){
				if(gameplayers[i].gameObject.GetInstanceID() == other.gameObject.GetInstanceID())
					gameplayer = gameplayers[i];
			}
            rb = other.gameObject.GetComponent<Rigidbody2D> ();
			animator = other.gameObject.GetComponent<Animator> ();
            if (Mathf.Abs(rb.velocity.y) > 0.001f){
                Debug.Log("Aaron : player killed by fall detector dead");
                gameplayer.trigger_dead();
            }
        }
    }
}
