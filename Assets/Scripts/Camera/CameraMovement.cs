using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject upperRightSquare;
    public GameObject upperLeftSquare;
    public GameObject lowerRightSquare;
    public GameObject lowerLeftSquare;

    void LateUpdate()
    {
        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Assume the player is initially in the upper right square
        GameObject targetSquare = upperRightSquare;

        // Compare the player's position with each square
        if (playerPosition.x < 0 && playerPosition.y > 0)
        {
            targetSquare = upperLeftSquare;
        }
        else if (playerPosition.x < 0 && playerPosition.y < 0)
        {
            targetSquare = lowerLeftSquare;
        }
        else if (playerPosition.x > 0 && playerPosition.y < 0)
        {
            targetSquare = lowerRightSquare;
        }

        // Set the camera's position to the center of the target square
        transform.position = targetSquare.transform.position;
    }
}
