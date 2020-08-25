using System;
using System.Collections.Generic;
using System.Text;

namespace gameserver
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }

        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }



        #region Packets
        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void SpawnPlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                //_packet.Write(_player.position);
                //_packet.Write(_player.rotation);

                //Console.WriteLine($"Send spawn packet {_player.username} ({_player.position.X}, {_player.position.Y}, {_player.position.Z})");
                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerPosition(Player _player) {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition)) {
                if (_player.animation_bools == null) {
                    _player.animation_bools = new List<bool>() { true, false, false, false, false, false, false, false, false };
                }
                if (_player.color_string == null)
                {
                    _player.color_string = System.Drawing.Color.White.ToString();
                }
                if (_player.username == null)
                {
                    _player.username = "egg";
                }
                if (_player.score == null)
                {
                    _player.score = 0;
                }
                //Console.WriteLine($"id:{_player.id} x:{_player.position}");
                _packet.Write(_player.id);
                _packet.Write(_player.position);
                _packet.Write(_player.animation_bools);
                _packet.Write(_player.color_string);
                _packet.Write(_player.username);
                _packet.Write(_player.score);
                SendUDPDataToAll(_packet);
            }
        }

        //public static void PlayerRotation(Player _player)
        //{
        //    using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
        //    {
        //        _packet.Write(_player.id);
        //        _packet.Write(_player.rotation);

        //        SendUDPDataToAll(_player.id, _packet);
        //    }
        //}
        #endregion

    }
}