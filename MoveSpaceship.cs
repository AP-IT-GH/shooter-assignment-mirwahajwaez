using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveSpaceship : MonoBehaviour
{
    public float xSpeed = 1f;
    public float ySpeed = 1f;
    public float xMinPos = -7.5f;
    public float xMaxPos = 7.5f;
    public float yMinPos = -7.5f;
    public float yMaxPos = 7.5f;

    void Update()
    {
        var pos = transform.localPosition;

        var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        var xOffset = horizontal * Time.deltaTime * xSpeed;
        var xPos = pos.x + xOffset;

        var vertical = CrossPlatformInputManager.GetAxis("Vertical");
        var yOffset = vertical * Time.deltaTime * ySpeed;
        var yPos = pos.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(xPos, xMinPos, xMaxPos), Mathf.Clamp(yPos, yMinPos, yMaxPos), pos.z);
    }
}
