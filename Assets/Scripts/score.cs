using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    Image img;
    playerData data;
    public GameObject player;

	// Use this for initialization
	void Start () {
        data = player.GetComponent<playerData>();
        img = GetComponent<Image>();
        img.fillAmount = 0.2f;

    }
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = data.GetScore() * 0.01f;
    }
}
