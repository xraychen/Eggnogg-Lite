using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainHub : MonoBehaviour
{
    private TextMeshProUGUI title;
    private TextMeshProUGUI label_01;
    private TextMeshProUGUI label_02;
    private TextMeshProUGUI label_03;
    private TextMeshProUGUI label_04;
    private GameObject label_04_obj;

    private TMP_InputField input_01;
    private TMP_InputField input_02;
    private TMP_InputField input_03;

    private Image color_button;

    private static List<Color> colors = new List<Color>() {Color.white, Color.gray, Color.green, Color.magenta, Color.red, Color.yellow, Color.blue};
    private int current_color_index = 0;

    private float timer;
    private bool connecting = false;

    // Start is called before the first frame update
    void Start()
    {
        title = gameObject.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        label_01 = gameObject.transform.Find("Label_01").GetComponent<TextMeshProUGUI>();
        label_02 = gameObject.transform.Find("Label_02").GetComponent<TextMeshProUGUI>();
        label_03 = gameObject.transform.Find("Label_03").GetComponent<TextMeshProUGUI>();
        label_04 = gameObject.transform.Find("Label_04").GetComponent<TextMeshProUGUI>();
        label_04_obj = gameObject.transform.Find("Label_04").gameObject;

        input_01 = gameObject.transform.Find("Input_01").GetComponent<TMP_InputField>();
        input_02 = gameObject.transform.Find("Input_02").GetComponent<TMP_InputField>();
        input_03 = gameObject.transform.Find("Input_03").GetComponent<TMP_InputField>();

        color_button = gameObject.transform.Find("Button_01").GetComponent<Image>();

        title.text = string_to_sprite("Wellcome to EGGNOGG LITE");
        label_01.text = string_to_sprite("IP");
        label_02.text = string_to_sprite("Port");
        label_03.text = string_to_sprite("Name");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(input_01.text);
        // Debug.Log(input_02.text);
    }

    void FixedUpdate() {
        if (connecting) {
            timer -= Time.deltaTime;
            if (timer < 0f) {
                label_04_obj.SetActive(true);
                label_04.text = string_to_sprite("Can not resolve server ], please try again!");
            }
        }
    }

    public void button_01_onclick() {
        Debug.Log("button 1 click");
        current_color_index = (current_color_index + 1) % colors.Count;
        color_button.color = colors[current_color_index];
    }

    // battle
    public void button_02_onclick() {
        Debug.Log("button 2 click");
        try
        {
            label_04_obj.SetActive(false);
            Client.instance.SERVER_IP = input_01.text;
            Client.instance.SERVER_PORT = Int32.Parse(input_02.text);
            Client.instance.user_name = input_03.text;
            Client.instance.color = colors[current_color_index];
            Client.instance.ConnectToServer(input_01.text, Int32.Parse(input_02.text));
            timer = 3f;
            connecting = true;
        }
        catch (System.Exception)
        {
            label_04_obj.SetActive(true);
            label_04.text = string_to_sprite("WRONG IP or Port format [, please try again!");
        }
    }

    string string_to_sprite(string text) {
        string output = "";
        foreach(char c in text) {
            if (c == ' ') {
                output += ' ';
            } else {
                output += $"<sprite name=\"{c}\" tint>";
            }
        }
        return output;
    }

}
