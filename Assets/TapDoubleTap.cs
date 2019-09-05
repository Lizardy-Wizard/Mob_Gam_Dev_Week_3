using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDoubleTap : MonoBehaviour
{
    // Start is called before the first frame update


    float tapTimer = 0f;
    public float doubleTapInterval = 0.2f;
    bool tapped = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (tapped) {
            tapTimer += Time.deltaTime;
            if (tapTimer > doubleTapInterval){
                SingleTap();
                tapped = false;
            }
        }

        if(Input.anyKeyDown) {
            // a tap happens
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }
        }
    }


    void SingleTap(){
        Debug.Log("<color=red>Single Tap!</color>");
        Debug.Log("Timer = " + tapTimer);

        tapTimer = 0;
        }

    void DoubleTap(){
        Debug.Log("<color=blue>Double Tap!</color>");
        Debug.Log("Timer = " + tapTimer);
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();
        this.transform.localScale += Vector3.one * 0.1f;
        if(this.transform.localScale.x > 5) {
            this.transform.localScale = Vector3.one;
        }
        tapTimer = 0;
    }

}
