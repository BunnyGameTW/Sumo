using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poop : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        // score--
        playerData col_data = col.gameObject.GetComponent<playerData>();
        if (col_data.GetPlayerState() == playerData.PlayerState.human)
        {
            col_data.SetScore(-1);
            col.gameObject.GetComponent<player>().stepPoop();
            // pic
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

}
