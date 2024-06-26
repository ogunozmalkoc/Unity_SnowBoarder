using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class crashDetector : MonoBehaviour
{

    [SerializeField] float AfterDeath = 1f;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCrashed && other.tag == "Ground" || other.tag =="Rock")
        {
            hasCrashed = true;
            FindObjectOfType<playerController>().DisableControls();
            deathEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", AfterDeath);
        }
    }

    
    //CircleCollider2D playerHead;

    //    void Start()
    //    {
    //        playerHead = GetComponent<CircleCollider2D>();
    //    }

    

    //void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        if (collision.gameObject.tag == "Ground" && playerHead.IsTouching(collision.gameObject.GetComponent<Collider2D>()))
    //        {
    //        deathEffect.Play();
    //            Invoke("ReloadScene", AfterDeath);
    //        }
    //    }

}
