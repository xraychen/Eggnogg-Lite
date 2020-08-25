using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const int count = 3;
    private int playerIDMAX = 0;
    public float respawnDelay = 2;
    public PlayerController[] gameplayers;
    public PlayerController gameplayer;
    public PlayerController gameplayernow;
    public bool playerscoreover20000 = false;
    //public PlayerController gameplayer;
    // Start is called before the first frame update
    void Start()
    {
        gameplayers = FindObjectsOfType<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int UpdateID(){
        return playerIDMAX++;
    }

    public int Detectplayernumber(){
        gameplayers = FindObjectsOfType<PlayerController> ();
        return  gameplayers.Length;
    }

    public void Respawn(int playerID){
        StartCoroutine("RespawnCoroutine", playerID);
    }

    public void Respawn2(int InstanceID){
        StartCoroutine("RespawnCoroutine2", InstanceID);
    }

    public IEnumerator RespawnCoroutine(int playerID){
        gameplayers = FindObjectsOfType<PlayerController> ();
        for(int i = 0; i < gameplayers.Length; i++){
            if(gameplayers[i].GetPlayerID() == playerID)
                gameplayer = gameplayers[i];
        }
        //gameplayer.score = gameplayer.score - 1;
        gameplayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(respawnDelay);
        gameplayer.transform.position = gameplayer.respawnpoint;
        gameplayer.gameObject.SetActive (true);
    }

    public IEnumerator RespawnCoroutine2(int InstanceID){
        gameplayers = FindObjectsOfType<PlayerController> ();
        for(int i = 0; i < gameplayers.Length; i++){
            if(gameplayers[i].gameObject.GetInstanceID() == InstanceID)
                gameplayer = gameplayers[i];
        }
        //gameplayer.score = gameplayer.score - 1;
		gameplayer.die_flag = false;
        gameplayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(respawnDelay);
        gameplayer.transform.position = gameplayer.respawnpoint;
        gameplayer.gameObject.SetActive (true);
    }
}