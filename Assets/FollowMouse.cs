using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera Camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0.0f; // Ensure the z position is 0 for 2D

        Vector3 worldPosition = Camera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0.0f; // Ensure the object stays at a constant z position in the world

        transform.position = worldPosition;
    }
}
