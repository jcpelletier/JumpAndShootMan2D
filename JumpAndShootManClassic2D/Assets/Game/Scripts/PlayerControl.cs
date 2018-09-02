using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerControl : MonoBehaviour {
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired player
    public Rigidbody2D bulletPrefab;

    public int movethrust = 20;
    public int jumpthrust = 10;
    private Rigidbody2D rb = null;
    private bool canjump;

    // Use this for initialization
    void Awake () {
        Physics2D.IgnoreLayerCollision(0, 9);
        canjump = true;
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.right * movethrust * player.GetAxis("Move")); // move left and right
        rb.velocity = new Vector2(player.GetAxis("Move")*5, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (player.GetAxis("Move") == 0)
        {
            rb.velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (player.GetAxis("Move") > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.GetAxis("Move") < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (player.GetButtonDown("Shoot"))
        {
            Debug.Log("shoot");
            Rigidbody2D clone;
            
            clone = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
            
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                clone.AddForce(transform.right * -10, ForceMode2D.Impulse);
            }
            else if (!gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                clone.AddForce(transform.right * 10, ForceMode2D.Impulse);
            }
        }

        if (player.GetButtonDown("Jump") && canjump)
        {
            Debug.Log("jump");
            rb.AddForce(transform.up * jumpthrust, ForceMode2D.Impulse);
            canjump = false;
        }

        if (player.GetButtonDown("Defense"))
        {
            Debug.Log("defense");
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Environment")
        {
            canjump = true;
        }
    }
}
