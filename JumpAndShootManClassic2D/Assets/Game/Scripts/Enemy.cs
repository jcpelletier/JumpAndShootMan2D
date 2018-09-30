using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool dirRight = true;
    public bool collisionCooldown = false;
    public float speed = 1.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("Hit Something " + col.gameObject.tag.ToString());
        if (col.gameObject.tag == "Wall" && collisionCooldown == false)
        {
            Debug.Log("Hit Environment");
            dirRight = !dirRight;
            collisionCooldown = true;
            StartCoroutine("CollisionCooldownTimer");
        }
    }

    IEnumerator CollisionCooldownTimer()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.1f);
        collisionCooldown = false;
    }
}
