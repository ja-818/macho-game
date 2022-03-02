using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainersBehaviour : MonoBehaviour
{
    //VARIABLES
    public bool hasChallenge;
    public bool hasCard;

    private float rotationOnTreshold = 10f;
    private bool playerOnTreshold;

    //REFERENCES
    private StatsUIManager statsUIManagerScript;

    private void Start()
    {
        statsUIManagerScript = GameObject.Find("Canvas").GetComponent<StatsUIManager>();
    }
    private void Update()
    {
        if(playerOnTreshold == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReactToContainer();
                Destroy(transform.parent.gameObject);
            }
        }
    }

    //Rotate when player is on treshold
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -rotationOnTreshold);
            playerOnTreshold = true;           
        }
    }

    //Rotate-back when pleayer exits treshold
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTreshold = false;
            transform.parent.gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, rotationOnTreshold);
        }
    }

    //Does something depending if it contained a challenge, a card, or nothing
    void ReactToContainer()
    {
        if (hasCard)
        {
            statsUIManagerScript.ChooseCard();
        }
        if (hasChallenge)
        {
            GameManager.Instance.isChallengeFound = true;
        }
        if (hasCard == false && hasChallenge == false)
        {
            Debug.Log("Paila So!");
        }
    }
}