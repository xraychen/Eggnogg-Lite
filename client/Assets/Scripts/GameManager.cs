using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Tuple<int, int>> top;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    public Dictionary<int, PlayerManager> get_players() {
        return players;
    }

    public void remove_player_by_id(int id) {
        players.Remove(id);
    }

    private void Start () {
        if (Screen.fullScreen)
        Screen.fullScreen = false;
    }

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
    }

    private void FixedUpdate() {
        List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
        foreach (KeyValuePair<int, PlayerManager> item in players)
        {
            if (item.Value.id == Client.instance.id) {
                temp.Add(new Tuple<int, int>(item.Key, Client.instance.score));
            } else {
                temp.Add(new Tuple<int, int>(item.Key, item.Value.score));
            }
        }
        temp.Sort((x, y) => y.Item2.CompareTo(x.Item2));
        // for (int i = 0; i < temp.Count; i++)
        // {
        //     Debug.Log($"{i} place score{temp[i]}");
        // }
        top = temp;
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Color color)
    {
        GameObject _player;
        if (_id == Client.instance.id)
        {
            _player = Instantiate(localPlayerPrefab, _position, Quaternion.identity);
            // _player.GetComponent<PlayerController>().set_color(color);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, Quaternion.identity);
            // GameObject textfield = _player.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject;
            // textfield.GetComponent<Text>().text = _username;
        }
        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        _player.GetComponent<PlayerManager>().me = _player;
        _player.GetComponent<PlayerManager>().color = color;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }
}
