using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savedata {
    
    public struct PlayerInfo
    {
        public int playerindex;
        public int selectChar;
        public playerData.Keys keys;
        public bool isJoin;
    }
    PlayerInfo [] players;
    public static Savedata save = new Savedata();
    // Use this for initialization
    public Savedata()
    {
        players = new PlayerInfo[4];
        setupPlayer();
       // Debug.Log(players.GetHashCode());
    }
	void setupPlayer()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].playerindex = i;
            players[i].selectChar = 999;//will error
            players[i].isJoin = false;
        }
        setupPlayerKeys();
    }
    void setupPlayerKeys()
    {
        players[0].keys.DownOrRight = KeyCode.D;
        players[0].keys.UpOrLeft = KeyCode.A;
        players[0].keys.Shoot = KeyCode.W;
        //
        players[1].keys.DownOrRight = KeyCode.L;
        players[1].keys.UpOrLeft = KeyCode.J;
        players[1].keys.Shoot = KeyCode.I;

        players[2].keys.DownOrRight = KeyCode.RightArrow;
        players[2].keys.UpOrLeft = KeyCode.LeftArrow;
        players[2].keys.Shoot = KeyCode.UpArrow;

        players[3].keys.DownOrRight = KeyCode.Keypad6;
        players[3].keys.UpOrLeft = KeyCode.Keypad4;
        players[3].keys.Shoot = KeyCode.Keypad8;
    }

    public void SetPlayers(PlayerInfo [] _players)
    {
        players = _players;
    }
    public PlayerInfo GetPlayer(int i)
    {
        return players[i];
    }
	public void SetPlayer(PlayerInfo _p, int index)
    {
        players[index] = _p;
    }
    public bool CheckOtherPlayerChar(PlayerInfo pin)//if anyone has select reutrn false
    {
        for(int i = 0; i < players.Length; i++)
        {
            if(pin.selectChar == players[i].selectChar && pin.playerindex != players[i].playerindex)
            {
                return false;
            }
        }
        return true;
      
    }
}
