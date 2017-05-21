using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorControllerOnGameWon : MonoBehaviour {


    Animator anim;
    private bool isGameWon = false;
    private float elapsedTime = 0;

    private GameObject thePlayer;
    
    // GameManager
    GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isGameWon)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= 2.0f)
            {
                //Destroy(thePlayer);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                gameManager.NewLevel();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("Player is here...");
            thePlayer = other.gameObject;
            anim.SetBool("isGameWon", true);
            isGameWon = true;
            DestroyObject(thePlayer.GetComponent<Rigidbody2D>());
            StartCoroutine(ScaleOverTime(2));
        }
    }


    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = thePlayer.transform.localScale;
        Vector3 destinationScale = new Vector3(0.10f, 0.10f, 0.10f);

        float currentTime = 0.0f;

        do
        {
            thePlayer.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(gameObject);
    }


}
