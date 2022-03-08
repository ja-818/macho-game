using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //VARIABLES
    private Vector2 movement;
    private float speed = 10f;

    //REFERENCES
    [SerializeField] Rigidbody2D playerRigidbody;
    private Vector3 startingPlayerPos;
    [SerializeField] private Color highlightColor;
    private Color playerColor;
    [SerializeField] CameraManager cameraManagerScript;


    private void Start()
    {
        startingPlayerPos = gameObject.transform.position;
        playerColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        StorePlayerInput();
        ReturnPlayerToStartPos();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!GameManager.Instance.isChallengeFound)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void ReturnPlayerToStartPos()
    {
        if (GameManager.Instance.isChallengeFound && gameObject.transform.position != startingPlayerPos)
        {
            gameObject.transform.position = startingPlayerPos;
        }
    }

    void StorePlayerInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isChallengeFound)
        {
            cameraManagerScript.LoadChallengeLevel();
        }
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance.isChallengeFound)
        {
            gameObject.GetComponent<SpriteRenderer>().color = highlightColor;
        }
    }

    private void OnMouseExit()
    {
        if (GameManager.Instance.isChallengeFound)
        {
            gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        }
    }
}
