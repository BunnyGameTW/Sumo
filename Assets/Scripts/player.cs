using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    playerData data;

    float timeCount,scoreTimer;
    public Sprite[] human;
    public Sprite[] monster;
    public GameObject[] bodypart;

    public GameObject poop;
    PlayerMusic music;
    // Use this for initialization
    void Start () {
        data = GetComponent<playerData>();
        scoreTimer = timeCount = 0;
        music = GetComponent<PlayerMusic>();

    }
	
	// Update is called once per frame
	void Update () {
        scoreTimer += Time.deltaTime;
        if(scoreTimer >= 3)
        {
            scoreTimer = 0;
            float tmpScore = data.GetScore();
            if(tmpScore > 10) data.SetScore(-10);
        }
        if(data.GetScore() >= 100.0f)
        {
            pooping();
            data.SetScore(-10);
        }
        Moving();

        if (data.GetPlayerState() == playerData.PlayerState.monster)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= 10)
            {
                timeCount -= 10.0f;
                TurnHuman();
            }
        }
	}

    void TurnMonster()
    {
        for (int i = 0; i < 5; i++)
        {
            bodypart[i].GetComponent<SpriteRenderer>().sprite = monster[i];
        }
        data.SetPlayerState(playerData.PlayerState.monster);
        
    }
    void TurnHuman()
    {
        for(int i = 0; i < 5; i++)
        {
            bodypart[i].GetComponent<SpriteRenderer>().sprite = human[i];
        }
        data.SetPlayerState(playerData.PlayerState.human);
    }
    public void stepPoop()
    {
        data.SetShit(1);
        if (data.GetShit() >= 5)
        {
            TurnMonster();
            data.SetShit(-5);
        }
    }

    public void pooping()
    {
        music.playMusic("poop");

        Instantiate(poop,transform.position,transform.rotation);
    }

    void Moving()
    {
        switch (data.GetPos())
        {
            case playerData.Pos.left:
            case playerData.Pos.right:
                if (Input.GetKey(data._keys.UpOrLeft))
                {
                    transform.position += new Vector3(0,Time.deltaTime*data.speed, 0);
                }
                else if (Input.GetKey(data._keys.DownOrRight))
                {
                    transform.position += new Vector3(0, -data.speed * Time.deltaTime, 0);
                }
                break;

            case playerData.Pos.up:
            case playerData.Pos.down:
                if (Input.GetKey(data._keys.UpOrLeft))
                {
                    transform.position += new Vector3( -data.speed * Time.deltaTime,0 , 0);
                }
                else if (Input.GetKey(data._keys.DownOrRight))
                {
                    transform.position += new Vector3( data.speed * Time.deltaTime,0 , 0);
                }
                break;

            default:
                break;
        }
    }
}
