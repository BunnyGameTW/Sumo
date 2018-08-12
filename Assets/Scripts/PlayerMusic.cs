using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour {
    public AudioClip poop;
    public AudioClip shoot;
    public AudioClip bounce;
    AudioSource source1,source2;
    // Use this for initialization
    void Start () {
        source1 = GetComponents<AudioSource>()[0];
        source2 = GetComponents<AudioSource>()[1];

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void playMusic(string _str)
    {
        if (_str == "poop")
        {
            source1.PlayOneShot(poop);
        }else if (_str == "bounce")
        {
            source2.PlayOneShot(bounce);
        }else if(_str == "shoot")
        {
            source2.PlayOneShot(shoot);
        }
    }
}
