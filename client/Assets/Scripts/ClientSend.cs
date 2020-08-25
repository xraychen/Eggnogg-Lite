using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.id);
            _packet.Write(Client.instance.user_name);
            Debug.Log("send welcome");

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(Vector3 _input, List<bool> animation_bools)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            Debug.Log(animation_bools.Count);
            _packet.Write(_input);
            _packet.Write(animation_bools);
            // _packet.Write(Client.instance.color.ToString());
            _packet.Write(ColorUtility.ToHtmlStringRGB(Client.instance.color));
            _packet.Write(Client.instance.user_name);
            _packet.Write(Client.instance.score);

            if (Client.instance.isConnected)
            {
                Debug.Log($"Send local player position ({_input.x}, {_input.y}, {_input.z})");
                // _packet.Write(GameManager.players[Client.instance.id].transform.rotation);
                // Debug.Log(GameManager.players[Client.instance.id].transform.rotation);
                SendUDPData(_packet);
            }
        }
    }
    #endregion
}
