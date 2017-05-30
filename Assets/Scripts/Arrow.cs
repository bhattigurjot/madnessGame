using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed = 4.0f;
    private GameObject enemy;
    private GameObject arrowEmitter;
    // Use this for initialization
    void Start() {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        arrowEmitter = GameObject.FindGameObjectWithTag("ArrowEmitter");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            EnemyController ec = (EnemyController) enemy.GetComponent<EnemyController>();
            if (ec.isFacingLeft)
            {
                transform.position += transform.up * Time.deltaTime * speed;
            }
            else
            {
                transform.position -= transform.up * Time.deltaTime * speed;
            }
        }
        else if (arrowEmitter != null)
        {
            transform.position += transform.up * Time.deltaTime * speed;
            
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Non-Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
