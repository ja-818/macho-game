using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //VARIABLES
    private Vector3 offset = new Vector3(0, 0, -5);
    private float smoothSpeed = 1f;
    private float timeToReturn = 1f;
    private float timer = 0f;
    bool isCameraPosStored;
    bool areInstructionsOn;
    Vector3 cameraReturnPos;

    //REFERENCES
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject instructionsPanel;
    private GameObject player;
    private Vector3 playerStartPos;
    private Vector3 cameraStartPos;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerStartPos = player.GetComponent<Transform>().position;
        cameraStartPos = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //Activate the instructions to select who does the challenge when the camera returns to the initial position
        if (isCameraPosStored && transform.position == cameraStartPos && !areInstructionsOn)
        {
            ActivateSelectChallengeInstructions();
        }
    }

    void FixedUpdate()
    {
        //Checks if the player has moved before following the player
        if (player.transform.position != playerStartPos && !gameManager.isChallengeFound)
        {
            FollowPlayer();
        }


        //Checks if the challenge is found to return to the start position
        if(gameManager.isChallengeFound && transform.position != cameraStartPos)
        {
            ReturnToStartPos();

            //Deactivates the stats panel
            statsPanel.gameObject.SetActive(false); 
        }
    }

    void FollowPlayer()
    {
        //Makes a smooth transition to the player when the player moves
        
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        //Removes the smoothnes gradually once the player moved
        if (smoothSpeed < 100f)
        {
            smoothSpeed += 0.5f;
        }

        //Activates the stats panel
        if(smoothSpeed < 2)
        {
            statsPanel.gameObject.SetActive(true);
        }
    }

    void ReturnToStartPos()
    {
        //Stores the position in which the camera currently is
        if (!isCameraPosStored)
        {
            cameraReturnPos = transform.position;
            isCameraPosStored = true;
        }

        //Returns the camera from the current position to the starting position on a fixed amount of time
        if(timer <= timeToReturn)
        {
            timer += Time.deltaTime;
            transform.position = cameraReturnPos + (cameraStartPos - cameraReturnPos) * (timer / timeToReturn);
        }
    }

    void ActivateSelectChallengeInstructions()
    {
            instructionsPanel.gameObject.SetActive(true);
            areInstructionsOn = true;
    }
}
