using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        Debug.Log($"Message from server: {_msg} id {_myId}");
        Client.instance.id = _myId;
        ClientSend.WelcomeReceived();
        Debug.Log("Get the welcome message");
        int _local = ((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port;
        Client.instance.udp.Connect(_local, Client.instance.SERVER_IP, Client.instance.SERVER_PORT);

        Score.instance.score_counter = 0;
        GameObject.Find("MainHub").SetActive(false);
        GameManager.instance.SpawnPlayer(_myId, Client.instance.user_name, new Vector2(0f, 1f), Client.instance.color);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        // int _id = _packet.ReadInt();
        // string _username = _packet.ReadString();
        // Vector3 _position = _packet.ReadVector3();

        // GameManager.instance.SpawnPlayer(_id, _username, _position);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        List<bool> _animation_bools = _packet.ReadListBools(10);
        string _color_string = _packet.ReadString();
        Color _color = Color.green;
        ColorUtility.TryParseHtmlString('#' + _color_string, out _color);

        string _username = _packet.ReadString();
        int _score = _packet.ReadInt();
        Debug.Log($"color string {_color_string}");
        Debug.Log($"color {_color}");
        Debug.Log($"username: {_username}");
        Debug.Log($"score: {_score}");
        // _color = Color.green;

        if ((_id != Client.instance.id))
        {
            Debug.Log($"UDP Message from server: {_id} and new position ({ _position.x}, {_position.y}, {_position.z})");
            try
            {
                // GameManager.players[_id].transform.position = _position;
                GameManager.players[_id].transform.position = new Vector2(_position.x, _position.y);
                GameManager.players[_id].update_animation(_animation_bools);
                GameManager.players[_id].update_score(_score);
            }
            catch (KeyNotFoundException e)
            {
                // do nothing, since we have not spawn the client
                GameManager.instance.SpawnPlayer(_id, _username, _position, _color);
                Debug.Log($"{e}");
            }
            GameManager.players[_id].idle_timer = 3f;
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        try
        {
            GameManager.players[_id].transform.rotation = _rotation;
        }
        catch (KeyNotFoundException e)
        {
            Debug.Log($"{e}");
            // do nothing, since we have not spawn the client
        }
    }

}
