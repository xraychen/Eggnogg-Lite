using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public int score;
    public string username;
    public GameObject me;
    private Animator animator;
    public float idle_timer;
    public Color color;
    public TextMeshProUGUI text_field;
    public GameObject canvas;

    public bool face_right = true;
    public GameObject body;
    public GameObject hand;
    private SpriteRenderer body_sprite;
    private SpriteRenderer hand_sprite;

    private List<string> animation_keys = new List<string>() {
        "is_running",
        "is_grounded",
        "is_raising",
        "is_falling",
        "is_run_attacking",
        "is_idle_attacking",
        "is_idle_sword_down",
        "is_idle_sword_up",
        "is_die"
    };

    void Start() {
        animator = GetComponent<Animator>();
        body_sprite = body.GetComponent<SpriteRenderer>();
        hand_sprite = hand.GetComponent<SpriteRenderer>();    }

    void FixedUpdate() {
        set_color(color);
        if (Client.instance.id != id) {
            text_field.text = string_to_sprite(username + "  " + score);
        } else {
            // text_field.text = "";
            text_field.text = string_to_sprite(username + "  " + Client.instance.score.ToString());
        }
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

    void flip(bool temp) {
        if ((temp && !face_right) || (!temp && face_right)) {
            transform.Rotate(0f, 180f, 0f);
            canvas.transform.Rotate(0f, 180f, 0f);
            face_right = temp;
        }
    }

    public void set_color(Color color) {
        body_sprite.color = color;
        hand_sprite.color = color;
    }

    public void update_animation (List<bool> animation_bools) {
        for (int i = 0; i < 9; i++)
        {
            //Debug.Log(i);
            //Debug.Log(animation_keys[i]);
            //Debug.Log(animation_bools[i]);
            animator.SetBool(animation_keys[i], animation_bools[i]);
        }
        flip(animation_bools[9]);
    }
    public void update_score(int _score) {
        score = _score;
    }
}
