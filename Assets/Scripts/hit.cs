using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class hit : MonoBehaviour {
    Rigidbody2D body;
    playerData data;
    public float shootStrength;
    public float hitStrength;
    float autoShootTimer;
    Vector2 shootVel;
    PlayerMusic music;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<playerData>();
        autoShootTimer = 0;
        music = GetComponent<PlayerMusic>();
    }
	
	// Update is called once per frame
	void Update () {
        shoot();
        //test
        if (Input.GetKeyDown(KeyCode.Q)) { data.SetPlayerState(playerData.PlayerState.monster); }
        autoShoot();
        detect();
    }
    void shoot()
    {
        if (Input.GetKeyDown(data._keys.Shoot) && data.GetPos()!=playerData.Pos.none ) { //shoot           
           body.AddForce(data.GetOppositePlayerPos() * shootStrength, ForceMode2D.Impulse);
            autoShootTimer = 0;
            data.SetPlayerPos(playerData.Pos.none);
            data.SetAnimation("fly");
            shootVel = body.velocity;
            music.playMusic("shoot");
        }
    }
    void autoShoot()
    {
        autoShootTimer += Time.deltaTime;
      
       if (data.GetPlayerState() == playerData.PlayerState.monster )
        {
            if (autoShootTimer > data.autoShootTime)
            {
                autoShootTimer = 0;
                body.AddForce(data.GetOppositePlayerPos() * shootStrength, ForceMode2D.Impulse);
                data.SetPlayerPos(playerData.Pos.none);
                data.SetAnimation("fly");
                music.playMusic("shoot");
            }

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Vector2 _vec2 = Vector2.zero;
        body.velocity = _vec2;
        _vec2 = transform.position - collision.transform.position;
        hitStrength = hitStrength * collision.gameObject.GetComponent<playerData>().playerSize;

        if (data.GetComponent<playerData>().GetPlayerPos() == Vector2.zero)
        {
           
            body.AddForce(_vec2 * hitStrength, ForceMode2D.Impulse);
            float f = Mathf.Acos(Vector2.Dot(shootVel.normalized, _vec2.normalized)) * Mathf.Rad2Deg;         
            transform.Rotate(0,0,f);
            shootVel = body.velocity;
            transform.DOPunchScale(new Vector3(Vector2.ClampMagnitude(_vec2, 0.1f).x, Vector2.ClampMagnitude(_vec2, 0.1f).y, 0), 1.0f, 5, 1);
            music.playMusic("bounce");
        }
    }
    void detect()
    {
        Vector3 _p = transform.position;
        if (transform.position.x < GameManager.game.LB.position.x) {
            _p.x = GameManager.game.LB.position.x;
            data.SetPlayerPos(playerData.Pos.left);
            body.velocity = Vector2.zero;
            data.SetAnimation("edge");
            data.SetBodyRot(playerData.Pos.left);
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        else if(transform.position.y < GameManager.game.LB.position.y)
        {
            _p.y = GameManager.game.LB.position.y;
            data.SetPlayerPos(playerData.Pos.down);
            body.velocity = Vector2.zero;
            data.SetAnimation("edge");
            data.SetBodyRot(playerData.Pos.down);
            transform.localScale = new Vector3(0.2f, 0.2f, 1);

        }
        else if (transform.position.x > GameManager.game.RT.position.x)
        {
            _p.x = GameManager.game.RT.position.x;
            data.SetPlayerPos(playerData.Pos.right);
            body.velocity = Vector2.zero;
            data.SetAnimation("edge");
            data.SetBodyRot(playerData.Pos.right);
            transform.localScale = new Vector3(0.2f, 0.2f, 1);

        }
        else if (transform.position.y > GameManager.game.RT.position.y)
        {
            _p.y = GameManager.game.RT.position.y;
            data.SetPlayerPos(playerData.Pos.up);
            body.velocity = Vector2.zero;
            data.SetAnimation("edge");
            data.SetBodyRot(playerData.Pos.up);
                        transform.localScale = new Vector3(0.2f, 0.2f, 1);

        }
        transform.position = _p;
    }
}
