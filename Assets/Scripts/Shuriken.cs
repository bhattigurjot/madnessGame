using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public AudioClip shurikenAudioClip;
    public float speed;
    AudioSource shurikenAudio;

	// Use this for initialization
	void Start () {
        shurikenAudio = GetComponent<AudioSource>();
        shurikenAudio.PlayOneShot(shurikenAudioClip, 0.50f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().enemyHealth -= 1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Non-Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
