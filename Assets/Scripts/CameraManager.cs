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
    Vector3 cameraReturnPos;

    //REFERENCES
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
      
    }

    void FixedUpdate()
    {
        if (player.transform.position != playerStartPos && !gameManager.isChallengeFound)
        {
            FollowPlayer();
        }

        if(gameManager.isChallengeFound && transform.position != cameraStartPos)
        {
            ReturnToStartPos();
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
    }

    void ReturnToStartPos()
    {

        if (!isCameraPosStored)
        {
            cameraReturnPos = transform.position;
            isCameraPosStored = true;
        }

        if(timer <= timeToReturn)
        {
            timer += Time.deltaTime;
            transform.position = cameraReturnPos + (cameraStartPos - cameraReturnPos) * (timer / timeToReturn);
        }
    }
}
