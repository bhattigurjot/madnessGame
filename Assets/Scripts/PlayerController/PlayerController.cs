using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //Player Controller Vars
    private bool isFacingRight = true;
    public float maxSpeed = 10.0f;
    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
    private bool doubleJump = false;


    //Player Health and Life
    private int playerMaxHealth = 100;
    private int playerCurrentHealth = 100;
    public GameObject bloodPrefab;

    //Camera shake
    private bool shakeEffect = false;
    private Vector3 startPos;
    public float shakeAmount;
    public float shakeTime;

    //Animator
    Animator anim;
    Animation animation;



    //Shooting and Actions
    public ShooterEmitter shooter;

    // GameManager
    GameManager gameManager;



    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        startPos = Camera.main.transform.position;
        anim = GetComponent<Animator>();
        animation = anim.GetComponent<Animation>();
        anim.SetBool("doIdle", true);
    }


    void FixedUpdate()
    {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        ////anim.SetBool("Ground", isGrounded);
        ////anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //if (isGrounded) doubleJump = false;


        ////Controll Player Horizontal Movement on input
        //float move = Input.GetAxis("Horizontal");
        ////anim.SetFloat("Speed", Mathf.Abs(move));
        //if (GetComponent<Rigidbody2D>() != null)
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //}



        ////Face towards the moving direction
        //if (move > 0 && !isFacingRight) playerFlip();
        //else if (move < 0 && isFacingRight) playerFlip();




    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", isGrounded);
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (isGrounded) doubleJump = false;


        //Controll Player Horizontal Movement on input
        float move = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", Mathf.Abs(move));
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }



        //Face towards the moving direction
        if (move > 0 && !isFacingRight) playerFlip();
        else if (move < 0 && isFacingRight) playerFlip();

        if ((isGrounded == true || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            //anim.SetBool("Ground", false);
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); ;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }

            if (!doubleJump && !isGrounded) doubleJump = true;
        }

        //Player shooting 
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("doAttack", true);
            //shooter.Shoot();
        }
        else
        {
            anim.SetBool("doAttack", false);
        }

        // Camera shake
        if (shakeEffect)
        {
            if (shakeTime > 0)
            {
                Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
                Camera.main.transform.position = new Vector3(startPos.x + shakePos.x, startPos.y + shakePos.y, startPos.z);
                shakeTime -= Time.deltaTime;
            }

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            shakeEffect = true;
            
            playerDies();            
        }

    }

    void playerFlip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void playerDies()
    {
        anim.SetTrigger("doDeath");

        StartCoroutine(WaitForAnimation());

        // Blood splatter - so disabling rigidbody2d and boxcollider2d
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject blood = (GameObject)Instantiate(bloodPrefab, new Vector2(transform.position.x, transform.position.y + 1.0f), Quaternion.identity);
        Destroy(blood, 2.0f);
    }
    public bool isPlayerAlive()
    {
        if (playerCurrentHealth <= 0) return false;
        return true;
    }
    public IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5F);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameManager.LoseLive();
    }
}
