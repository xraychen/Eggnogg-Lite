using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text;
using System.Diagnostics;

namespace gameserver
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine(_fromClient);
            Console.WriteLine(_clientIdCheck);
            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient} as username : {_username}");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            Server.clients[_fromClient].SendIntoGame(_username);
        }

        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            Vector3 _position = _packet.ReadVector3();
            List<bool> _animation_bools = _packet.ReadListBools(10);
            string _color_string = _packet.ReadString();
            string _username = _packet.ReadString();
            int _score = _packet.ReadInt();
            try
            {
                Server.clients[_fromClient].player.SetInput(_position, _animation_bools, _color_string, _username, _score);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine($"{e}");
            }
            

        }
    }
}
