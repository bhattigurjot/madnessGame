using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour {


    //CanvasRenderer controllerCanvas;
    public Sprite controllerSprite;

    GameObject controllerImageObject;
    public float duration = 5;
    public float smooth = 0.02F;
    Color colorStart, colorEnd;
    Color currentColor;
    Color alpha;



    public bool sawOnce = false;

    // Poor coding - to give a very fast hack fix
    public static bool sawOnceLRTrigger = false;
    public static bool sawOnceJumpTrigger = false;
    public static bool sawOnceDoubleJumpTrigger = false;
    public static bool sawOnceFireTrigger = false;

    private string controllerName = "";

    // Use this for initialization
    void Start()
    {
        controllerImageObject = GameObject.Find("ControllerImage");
        currentColor = controllerImageObject.GetComponent<SpriteRenderer>().color;
        alpha = currentColor;
        alpha.a = 0f;

        colorStart = controllerImageObject.GetComponent<SpriteRenderer>().color;
        colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0F);
    }

    // Update is called once per frame
    void Update()
    { 

    }

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if(gameObject.name == "LeftRightTrigger" && !sawOnceLRTrigger)
        {
            controllerImageObject.GetComponent<SpriteRenderer>().color = alpha;
            controllerSprite = Resources.Load("LRController", typeof(Sprite)) as Sprite;
            sawOnceLRTrigger = true;
            controllerName = gameObject.name;
        }
        else if (gameObject.name == "JumpTrigger" && !sawOnceJumpTrigger)
        {
            controllerImageObject.GetComponent<SpriteRenderer>().color = alpha;
            controllerSprite = Resources.Load("JumpController", typeof(Sprite)) as Sprite;
            sawOnceJumpTrigger = true;
            controllerName = "JumpTrigger";
        }
        else if (gameObject.name == "DoubleJumpTrigger" && !sawOnceDoubleJumpTrigger)
        {
            controllerImageObject.GetComponent<SpriteRenderer>().color = alpha;
            controllerSprite = Resources.Load("DoubleJumpController", typeof(Sprite)) as Sprite;
            sawOnceDoubleJumpTrigger = true;
            controllerName = "DoubleJumpTrigger";
        }
        else if (gameObject.name == "FireTrigger" && !sawOnceFireTrigger)
        {
            controllerImageObject.GetComponent<SpriteRenderer>().color = alpha;
            controllerSprite = Resources.Load("FireController", typeof(Sprite)) as Sprite;
            sawOnceFireTrigger = true;
            controllerName = "FireTrigger";
        }
 
            controllerImageObject.GetComponent<SpriteRenderer>().sprite = controllerSprite;
            if (gameObject.name != controllerName)
            {
                controllerImageObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else controllerImageObject.GetComponent<SpriteRenderer>().enabled = true;

            if (sawOnce == false)
            {
                StartCoroutine("LerpColor");
            }
    }
    IEnumerator LerpColor()
    {
        sawOnce = true;
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smooth / duration; //The amount of change to apply.
        while (progress < 1)
        {
            currentColor = Color.Lerp(colorStart, colorEnd, progress);
            controllerImageObject.GetComponent<SpriteRenderer>().color = currentColor;
            progress += increment;
            yield return new WaitForSeconds(smooth);
        }
        yield return true;
        controllerImageObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    //public IEnumerator WaitForAnimation()
    //{
    //    yield return new WaitForSeconds(0.1F);
    //}
}
