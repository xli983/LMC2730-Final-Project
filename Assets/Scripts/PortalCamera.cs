using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public Transform playerBody; // Reference to the player's body for Y rotation

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        Quaternion rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        // Set Camera_B's rotation
        float xRotation = playerCamera.eulerAngles.x;
        float yRotation = playerBody.eulerAngles.y;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
