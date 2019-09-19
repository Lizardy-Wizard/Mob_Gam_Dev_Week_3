using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound : MonoBehaviour
{
    AudioSource aud;
    public AudioClip clip;
    public int totalPickups = 0;

    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        this.GetComponent<Collider>().isTrigger = true;    
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Something Hit Me!");
        if(other.gameObject.CompareTag("Player")){
            aud.PlayOneShot(clip);
            totalPickups++;
            //System.Threading.Thread.Sleep(1000);
            //Destroy(this.gameObject);
            StartCoroutine(Wait ());
        } else {
            Debug.Log("It Wasn't the Player...");
        }
    }

    IEnumerator  Wait(){
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
