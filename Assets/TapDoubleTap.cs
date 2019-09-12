using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDoubleTap : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Is this working?
    
    float tapTimer = 0f;
    public float doubleTapInterval = 0.2f;
    bool tapped = false;
    public int intHealth = 3;
    public int intCounter = 0;
    public int intEnemyCount = 10;
    


    void Start()
    {
        
       this.GetComponent<Renderer>().material.color = Random.ColorHSV();
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
        if (intEnemyCount <= 0){
            
        }


    }


    void SingleTap(){
        Debug.Log("<color=red>Single Tap!</color>");
        Debug.Log("Timer = " + tapTimer);
        intHealth -= 1;
        Debug.Log("Health is at " + intHealth);
        if (intHealth <= 0){
            intCounter+= 1;
            intEnemyCount -= 1;
            this.GetComponent<Renderer>().material.color = Random.ColorHSV();
            this.transform.localScale += Vector3.one * 0.1f;
            intHealth += intCounter;
        }
        tapTimer = 0;
        }

    void DoubleTap(){
        Debug.Log("<color=blue>Double Tap!</color>");
        Debug.Log("Timer = " + tapTimer);
        intHealth -= 2;
        Debug.Log("Health is at " + intHealth);
        if (intHealth <= 0){
            intCounter += 1;
            intHealth = 3;
            intEnemyCount -= 1;
            this.GetComponent<Renderer>().material.color = Random.ColorHSV();
            this.transform.localScale += Vector3.one * 0.1f;
            intHealth += intCounter;
        }
        
        if(this.transform.localScale.x > 5) {
            this.transform.localScale = Vector3.one;
            intHealth = 3;
            intCounter = 0;
        }
        tapTimer = 0;
    }

}
