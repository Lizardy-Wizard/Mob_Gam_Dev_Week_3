using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Controls : MonoBehaviour
{

    Renderer rend;
    Color originalColor;
    float time = 0f;
    
    Vector3 position;
    float width;
    float height;
    bool timer_is_going;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        originalColor = rend.material.color;
        width = (float)Screen.width / 2f;
        height = (float)Screen.height / 2f;
        position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {

       // if(timer_is_going){
            //Debug.Log("The Timer is Going");
            //time += Time.deltaTime;
            //if(time > 4 ){
                //rend.material.color = Color.red;
            //}
            //else if(time > 2){
                //rend.material.color = Color.yellow;
            //}

        //}

        if(Input.touchCount > 0){
            Debug.Log("I have been tapped");
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                rend.material.color = Color.green;
                timer_is_going = true; 
                if(timer_is_going){
                    Debug.Log("IS THIS GOING?");
                    time += Time.deltaTime;
                    if(time > 4){
                        rend.material.color = Color.red;
                    }
                    if(time > 2){
                        rend.material.color = Color.yellow;
                    }
                }
 
            } 
            

            
            if(touch.phase == TouchPhase.Moved) {
                Vector2 pos = touch.position;
                Debug.Log("Touch Postition = " + touch.position);

                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x, pos.y, 0);

                this.transform.position = position;
            }
            if(touch.phase == TouchPhase.Ended)
                rend.material.color = originalColor;
                timer_is_going = false;
                //time = 0;    
        }

        if(Input.touchCount <= 1){
            this.transform.localScale = Vector3.one;
        }
        if(Input.touchCount == 2){
            this.transform.localScale = Vector3.one * 2;
        }
        if(Input.touchCount == 3)
        this.transform.localScale = Vector3.one *3;

    }
}
