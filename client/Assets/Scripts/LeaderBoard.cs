using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    private TextMeshProUGUI text_field;
    // Start is called before the first frame update
    void Start()
    {
        text_field = gameObject.transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        List<Tuple<int, int>> top = GameManager.instance.top;
        Dictionary<int, PlayerManager> players = GameManager.instance.get_players();
        string text = "";
        for (int i = 0; i < Mathf.Min(3, top.Count); i++)
        {
            string username;
            int score;
            int idx = top[i].Item1;
            // Debug.Log($"xray {idx} {Client.instance.id}");
            if (idx == Client.instance.id) {
                username = Client.instance.user_name;
                score = Client.instance.score;
            } else {
                username = players[idx].username;
                score = players[idx].score;
            }
            text += $"TOP {i+1}: " + username + "  " + score + '\n';
        }
        text_field.text = string_to_sprite(text);
    }

    string string_to_sprite(string text) {
        string output = "";
        foreach(char c in text) {
            if (c == ' ' || c == '\n') {
                output += c;
            } else {
                output += $"<sprite name=\"{c}\" tint>";
            }
        }
        return output;
    }
}
