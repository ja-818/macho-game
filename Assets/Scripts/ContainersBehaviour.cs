using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainersBehaviour : MonoBehaviour
{
    //VARIABLES
    bool playerOnTreshold;
    public bool hasChallenge;
    public bool hasCard;
    float rotationOnTreshold = 10f;

    //REFERENCES
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(playerOnTreshold == true)
        {
            DestroyObjectOnClick();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -rotationOnTreshold);
            playerOnTreshold = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTreshold = false;
            transform.parent.gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, rotationOnTreshold);
        }
    }

    void DestroyObjectOnClick()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hasCard)
                {
                    gameManager.ChooseCard();
                }
                if (hasChallenge)
                {
                    gameManager.isChallengeFound = true;
                }
                if (hasCard == false && hasChallenge == false)
                {
                    Debug.Log("Paila so!");
                }

                Destroy(transform.parent.gameObject);
            }
    }
}
