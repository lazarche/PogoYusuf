using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rig;

    AudioSource aso;
    Vector2 target;
    Animator ani;

    GameObject touched = null;

    bool dead = false;

    [SerializeField] float limit_min = -2, limit_max = 2;
    [SerializeField] GameObject particle;
    
    [SerializeField] AudioClip[] stone;
    [SerializeField] AudioClip[] dirt;
    void Start()
    {
        aso = GetComponent<AudioSource>();
        ani = GetComponentInChildren<Animator>();
        target = transform.position;
        rig = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(float pom) {
        if(dead || GameManager.instance.isWin())
            return;

        if(!GameManager.instance.isStarted() && Mathf.Approximately(pom, 0)) {
            GameManager.instance.StartLevel();
            rig.velocity += new Vector2(0,-20);
            return;
        }

        if(!GameManager.instance.isStarted())
            return;

        if(pom > 0 && target.x < limit_max) 
            target = target + new Vector2(1,0);
            else if( pom < 0 && target.x > limit_min)
            target = target + new Vector2(-1,0);
            else 
                rig.velocity += new Vector2(0,-20);
    }

    void FixedUpdate() {
        ani.SetFloat("spd", rig.velocity.y);
        if(rig.position.x != target.x) {
            rig.velocity = new Vector2(10 * Mathf.Sign(target.x - rig.position.x), rig.velocity.y);
            if(Mathf.Abs(rig.position.x - target.x) < 0.1f) {
                rig.MovePosition(new Vector2(target.x, rig.position.y));
                rig.velocity = new Vector2(0 , rig.velocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(dead)
            return;

        if(col.gameObject.tag.Equals("Ground")){
            col.gameObject.GetComponent<BlockScript>().TakeHit();
            rig.AddForce(Vector2.up * 500 * rig.gravityScale);
            touched = null;
            aso.clip = stone[Random.Range(0,stone.Length)];
            aso.Play();
        } else if(col.gameObject.tag.Equals("DestroyableBlock")) {
            touched = null;
            col.gameObject.GetComponent<BlockDestroy>().TakeHit();
            rig.AddForce(Vector2.up * 500);
            aso.clip = dirt[Random.Range(0,dirt.Length)];
            aso.Play();
        }
    }
    void OnCollisionStay2D(Collision2D col) {
        if(dead)
            return;

        if(!col.gameObject.Equals(touched))
            return;

        touched = col.gameObject;

        if(col.gameObject.tag.Equals("Ground")){
            col.gameObject.GetComponent<BlockScript>().TakeHit();
            rig.AddForce(Vector2.up * 500 * rig.gravityScale);
        } else if(col.gameObject.tag.Equals("DestroyableBlock")) {
            col.gameObject.GetComponent<BlockDestroy>().TakeHit();
            rig.AddForce(Vector2.up * 500);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag.Equals("PecPec") && !dead) {
            dead = true;
            Instantiate(particle, transform.position, Quaternion.identity);
            foreach (Renderer item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
            UiManager.instance.LoseLevel();
        } else if(col.tag.Equals("Coin")) {
            UiManager.instance.addMoney(1);
            Destroy(col.gameObject);
        } else if(col.tag.Equals("Win") && !GameManager.instance.isWin())
            GameManager.instance.WinLevel();
    }
}
