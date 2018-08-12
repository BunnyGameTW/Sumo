using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAni : MonoBehaviour {
    public GameObject[] mask;
    public GameObject mask2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseOver()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    mask[i].SetActive(true);
        //    Wait();
        //}
        mask2.SetActive(true);
    }
    private void OnMouseExit()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    mask[i].SetActive(false);
        //}

        mask2.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
