using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool isFacingLeft { get; set; }
    public float maxSpeed = 10.0f;

    //Animator
    Animator anim;
    Animation animation;

    // Use this for initialization
    void Start () {
        isFacingLeft = true;
	}
    
    void FixedUpdate()
    {        
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2((isFacingLeft ? -1 : 1) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void playerFlip()
    {        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
