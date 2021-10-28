using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

    public float rotateY=45;
    public GameObject child;
    
	// Use this for initialization
	void Start () {
        child = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        rotateY += horizontal;
        transform.localRotation = Quaternion.Euler(0, rotateY, 0);
	}
}
