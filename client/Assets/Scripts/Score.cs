using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Transform player;
    public Text score;
    private string str_score;
    private List<int> score_list;
    public int score_counter = 0;
    private int death_times = 0;
    public PlayerController[] gameplayers;
    public PlayerController gameplayer;
    //public Text scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    void Start()
    {
        //str_score = "100";
    }

    // Update is called once per frame
    void Update()
    {
        score_counter += 2;
        score = GetComponent<Text>();
        score.text = score_counter.ToString();
    }

    public void DeathPunishment(int minus)
    {
        death_times++;
        if(score_counter > 0){
            score_counter = score_counter -= 1000;
        }
        score_counter = score_counter - minus * death_times;
    }
}