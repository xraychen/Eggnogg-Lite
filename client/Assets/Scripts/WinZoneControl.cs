using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneControl : MonoBehaviour
{
    public GameObject win_animation;
    public LevelManager gameLevelManager;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        win_animation = GameObject.Find("Background_win");
        gameLevelManager = FindObjectOfType<LevelManager>();
        animator = win_animation.GetComponent<Animator>();
        animator.SetBool("is_win", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "player"){
            if(gameLevelManager.playerscoreover20000){
                animator.SetBool("is_win", true);
            }
        }
    }
}
