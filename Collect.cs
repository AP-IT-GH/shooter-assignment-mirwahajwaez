using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            var obj = GameObject.FindGameObjectWithTag("Score").gameObject;
            obj.GetComponent<Text>().text = (int.Parse(obj.GetComponent<Text>().text) + 1).ToString();
            print("Collected!");
        }
    }
}
