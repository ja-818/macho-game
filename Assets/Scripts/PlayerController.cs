using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;
    private GameManager gameManager;
    private Vector3 startingPlayerPos;

    private Vector2 movement;
    private float speed = 10f;

    private Color playerColor;
    [SerializeField] private Color highlightColor;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        if (!gameManager.isChallengeFound)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void ReturnPlayerToStartPos()
    {
        if (gameManager.isChallengeFound && gameObject.transform.position != startingPlayerPos)
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
        if (gameManager.isChallengeFound)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnMouseOver()
    {
        if (gameManager.isChallengeFound)
        {
            gameObject.GetComponent<SpriteRenderer>().color = highlightColor;
        }
    }

    private void OnMouseExit()
    {
        if (gameManager.isChallengeFound)
        {
            gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        }
    }
}
