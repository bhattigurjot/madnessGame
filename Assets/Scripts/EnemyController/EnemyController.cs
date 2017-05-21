using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool isFacingLeft { get; set; }
    public float maxSpeed = 10.0f;
    public bool shouldShoot = false;
    public bool shouldWalk = false;
    public int enemyHealth = 3;

    //Animator
    Animator anim;
    Animation animation;

    // Use this for initialization
    void Start () {
        isFacingLeft = true;
        anim = GetComponent<Animator>();
        animation = anim.GetComponent<Animation>();
    }

    void Update()
    {
        //anim.SetBool("doAttack", shouldShoot);
        anim.SetBool("doWalk", shouldWalk);

        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>() != null && shouldWalk)
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
