using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject upperRightSquare;
    public GameObject upperLeftSquare;
    public GameObject lowerRightSquare;
    public GameObject lowerLeftSquare;

    //Grab the other file we need to use here
    public bool CameraTilted;

    void LateUpdate()
    {
        if (!CameraTilted)
        {
            // Get the player's position
            Vector3 playerPosition = transform.position;

            // Assume the player is initially in the upper right square
            GameObject targetSquare = upperRightSquare;

<<<<<<< Updated upstream

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

            // Get the center position of the target square
            Vector2 targetPosition = targetSquare.transform.position;

            // Set the camera's position to the center of the target square
            Camera.main.transform.position = new Vector3(targetPosition.x, targetPosition.y, -1f);
        }
        else
        {
            // Set the camera's position to the center of the target square
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0, -1f);
        }
        
=======
        // Set the camera's position to the center of the target square
        Camera.main.transform.position = new Vector3(targetPosition.x, targetPosition.y, Camera.main.transform.position.z);
>>>>>>> Stashed changes
    }

    

}
