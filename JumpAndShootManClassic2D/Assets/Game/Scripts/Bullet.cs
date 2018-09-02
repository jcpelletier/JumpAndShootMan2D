using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Environment")
        {
            gameObject.SetActive(false);
        }
    }
}
