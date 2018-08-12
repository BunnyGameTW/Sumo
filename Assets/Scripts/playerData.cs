using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerData : MonoBehaviour {
    public enum Pos
    {
        left,right,up,down,none
    }
    public Pos _pos;
    public float speed;
    [System.Serializable]
    public struct Keys
    {
        public KeyCode UpOrLeft;
        public KeyCode DownOrRight;
        public KeyCode Shoot;
    }
    public Keys _keys;
    public enum PlayerState { human, monster}
    public PlayerState _playerState;
    public float playerSize;
    public int playerScore;
    public int playerShit;
    public float autoShootTime;
    //angel add
    public float monsterTime;
    Animator ani;
    // Use this for initialization
    void Start () {
        autoShootTime = 3;
        playerScore = 60;
        playerShit = 0;
        _pos = Pos.none;
        playerSize = 1;
        _playerState = PlayerState.human;
        monsterTime = 10;
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector2 GetPlayerPos()
    {
        Vector2 _vec2 = Vector2.zero;
        if (_pos == Pos.left) _vec2 = Vector2.left;
        else if(_pos == Pos.right) _vec2 = Vector2.right;
        else if (_pos == Pos.up) _vec2 = Vector2.up;
        else if (_pos == Pos.down) _vec2 = Vector2.down;
        
        return _vec2;
    }
    public void SetPlayerPos(Pos _p)
    {
        _pos = _p;
       // Debug.Log(name + ", " + _pos);
    }
    public void SetPlayerPos(string _str)
    {
        if (_str == "left") _pos = Pos.left;
        else if (_str == "right") _pos = Pos.right;
        else if (_str == "up") _pos = Pos.up;
        else if (_str == "down") _pos = Pos.down;
        else _pos = Pos.none;
       // Debug.Log(name + ", " + _pos);

    }

    public Pos GetPos()
    {
        return _pos;
    }

    public Vector2 GetOppositePlayerPos()
    {
        Vector2 _vec2 = Vector2.zero;
        if (_pos == Pos.left) _vec2 = Vector2.right;
        else if (_pos == Pos.right) _vec2 = Vector2.left;
        else if (_pos == Pos.up) _vec2 = Vector2.down;
        else if (_pos == Pos.down) _vec2 = Vector2.up;
        return _vec2;
    }
    public void SetPlayerState(PlayerState _state)
    {
        _playerState = _state;
    }
    public PlayerState GetPlayerState()
    {
        return _playerState;
    }
    public void SetScore(int num)
    {
        playerScore += num;
    }
    public int GetScore()
    {
        return playerScore;
    }
    public void SetShit(int num)
    {
        playerShit += num;
    }
    public int GetShit()
    {
        return playerShit;
    }
    public void SetAnimation(string _str)
    {
        if (_str == "fly") ani.SetBool("isFly", true);
        else ani.SetBool("isFly", false);
    }
    public void SetBodyRot(Pos _p)
    {
        if(_p == Pos.left) { transform.rotation =  Quaternion.Euler(0, 0, -90.0f); }
        else if(_p == Pos.right){transform.rotation = Quaternion.Euler(0, 0,90.0f); }
        else if (_p == Pos.up) { transform.rotation = Quaternion.Euler(0, 0, 180.0f); }
        else if (_p == Pos.down) { transform.rotation = Quaternion.Euler(0, 0, 0.0f); }

    }
   
}
