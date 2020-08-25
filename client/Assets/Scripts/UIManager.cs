using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // public GameObject startMenu;
    // public InputField usernameField;
    // public InputField IPaddress;
    // public InputField Port;
    private string IP = "192.168.0.1";
    private int PORT = 8000;

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
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        // startMenu.SetActive(false);
        // usernameField.interactable = false;
        Client.instance.ConnectToServer(IP, PORT);
        Debug.Log("test for connect to server with TCP");
    }

    public void ConnectToServerUDP(int _local)
    {
        Client.instance.udp.Connect(_local, IP, PORT);
        Debug.Log("test for connect to server with UDP");
    }
}
