using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour {

    public AudioClip audioClip;
    public GameObject explosionParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            print("hit");
            print(transform.position);
             Instantiate(explosionParticle, transform.position,transform.rotation);
            //DO explosion
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }

            var obj = GameObject.FindGameObjectWithTag("Score").gameObject;
            obj.GetComponent<Text>().text = (int.Parse(obj.GetComponent<Text>().text) + 3).ToString();
            Destroy(gameObject);
            Destroy(other.gameObject);
            print("Earned 3 points!");
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().ApplyDamage(3);
        }
    }
}
