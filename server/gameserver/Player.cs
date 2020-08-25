using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Runtime.InteropServices;

namespace gameserver
{
    class Player
    {
        public int id;
        //public string username;

        public Vector3 position;
        //public List<bool> animation_bools;
        public Quaternion rotation;

        private Vector3 inputs;
        public List<bool> animation_bools;
        public string color_string;
        public string username;
        public int score;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;

            inputs = new Vector3();
        }

        public void Update()
        {
            Vector2 _inputDirection = Vector2.Zero;
            Move(_inputDirection);
        }

        private void Move(Vector2 _inputDirection)
        {
            this.position = inputs;
            ServerSend.PlayerPosition(this);
        }

        //public void SetInput(Vector3 _inputs, Quaternion _rotation)
        //{
        //    inputs = _inputs;
        //    rotation = _rotation;
        //}

        public void SetInput(Vector3 _inputs, List<bool> _animation_bools, string _color_string, string _username, int _score)
        {
            inputs = _inputs;
            animation_bools = _animation_bools;
            color_string = _color_string;
            username = _username;
            score = _score;
        }
    }
}
