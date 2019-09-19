using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour

{

    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
        Debug.Log("I am working");
        time += Time.deltaTime;
        if(time > 2){
           // Destroy(gameObject);
        }
        //
        }
    }
}
