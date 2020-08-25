using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        title = GetComponent<TextMeshProUGUI>();
        title.text = string_to_sprite("Wellcome to EGGNOGG LITE");
    }

    string string_to_sprite(string text) {
        string output = "";
        foreach(char c in text) {
            if (c == ' ') {
                output += ' ';
            } else {
                output += $"<sprite name=\"{c}\">";
            }
        }
        return output;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
