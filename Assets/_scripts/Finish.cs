using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   private AudioSource finishSoundEffect;
   private bool levelCompeleted = false;
    void Start()
    {
        finishSoundEffect  = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player" && !levelCompeleted){
            finishSoundEffect.Play();
            levelCompeleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    
    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
