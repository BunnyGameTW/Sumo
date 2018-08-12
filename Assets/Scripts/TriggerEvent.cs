using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerEvent : MonoBehaviour {
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 _vec2 = collision.GetComponent<playerData>().GetPlayerPos();
        if (_vec2 == Vector2.zero)
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        collision.GetComponent<playerData>().SetPlayerPos(name);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 _vec2 = collision.GetComponent<playerData>().GetPlayerPos();
        if (_vec2 == Vector2.zero)
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        collision.GetComponent<playerData>().SetPlayerPos(name);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<playerData>().SetPlayerPos("none");
    }
}
