using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food : MonoBehaviour {


    public int score;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        playerData col_data = col.gameObject.GetComponent<playerData>();

        col_data.SetScore(5);

        this.gameObject.SetActive(false);
        GameManager.game.GetComponent<FoodSystem>().food_Unused.Enqueue(this.gameObject);
    }
}
