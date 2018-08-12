using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public static GameManager game;
    public enum GameState { select, ready, start, over}
    GameState _gameState;
    public float gameTime;
    public Transform LB, RT;
    public Text timeTxt;
    float timeCount;
    FoodSystem food_system;
    public GameObject endUI;
    Savedata.PlayerInfo[] _players;
    public GameObject[] playerObj;
    public GameObject[] playerUI;
    // Use this for initialization
    void Awake () {
        if (game == null) game = this;     
	}
    private void Start()
    {
        food_system = gameObject.GetComponent<FoodSystem>();
        food_system.setup();
        food_system.ShowFood();
        _gameState = GameState.start;
        _players = new Savedata.PlayerInfo[4];
        for (int i = 0; i < 4; i++)
        {
            _players[i] = Savedata.save.GetPlayer(i);
            if (_players[i].isJoin)
            {
                playerUI[i].SetActive(true);
                playerObj[i].SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update () {
      
        if (_gameState == GameState.start)
        {       
            timeCount += Time.deltaTime;
            gameTime -= Time.deltaTime;
            timeTxt.text = ((int)gameTime).ToString();
            if (timeCount >= 8.0f)
            {
                food_system.ShowFood();
                timeCount -= 8.0f;
            }
            if(gameTime <= 0.0f) {
                _gameState = GameState.over;
                int winner = checkWinner();
                Debug.Log("winner " + winner);
                Debug.Log("game Over");
                //set winner image
                endUI.SetActive(true);

            }
        }

        if (_gameState == GameState.over)
        {
            if (Input.GetKeyDown(KeyCode.Return)) UnityEngine.SceneManagement.SceneManager.LoadScene("Begin");
        }
    }
    int checkWinner()
    {
        float maxScore = -1;
        int winnerIndex = 0;
        playerData [] playerDatas = FindObjectsOfType<playerData>();
        for (int i = 0; i < playerDatas.Length; i++)
        {
            if (maxScore < playerDatas[i].GetScore())
            {
                maxScore = playerDatas[i].GetScore();
                winnerIndex = i;
            }
        }
        endUI.GetComponentsInChildren<Image>()[1].sprite = playerDatas[winnerIndex].GetComponentInChildren<SpriteRenderer>().sprite;

        return winnerIndex;
    }
}
