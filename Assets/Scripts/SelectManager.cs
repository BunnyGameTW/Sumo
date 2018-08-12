using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour {
   
    Savedata.PlayerInfo[] _players;
    public GameObject[] playerImage;
    public Sprite[] charImg;
    public GameObject[] playerHintObj;
    public GameObject enterText;
    private void Awake()
    {
        Savedata.save = new Savedata();
    }
    // Use this for initialization
    void Start () {
        _players = new Savedata.PlayerInfo[4];
        for (int i = 0; i < 4; i++)
        {
            _players[i] = Savedata.save.GetPlayer(i);
        }
    }
	
	// Update is called once per frame
	void Update () {
        join();
        enterGame();
	}
    void join()
    {   
        for (int i = 0; i < _players.Length; i++) {
            if (Input.GetKeyDown(_players[i].keys.Shoot) && !_players[i].isJoin)
            {
                _players[i].isJoin = true;
                playerHintObj[i].SetActive(false);
                playerImage[i].SetActive(true);
                _players[i].selectChar = i;
                playerImage[i].GetComponentsInChildren<Image>()[0].sprite = charImg[_players[i].selectChar];
                Savedata.save.SetPlayer(_players[i], i);
                enterText.SetActive(true);
            }
        } 
    }
    void enterGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
