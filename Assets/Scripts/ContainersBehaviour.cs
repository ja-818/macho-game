using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersBehaviour : MonoBehaviour
{
    bool playerOnTreshold;
    public bool hasCard;
    public bool hasChallenge;
    float rotationOnTreshold = 10f;

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
                    Debug.Log("Card Found!");
                }
                if (hasChallenge)
                {
                    Debug.Log("Challenge Found!");
                }
                if (hasCard == false && hasChallenge == false)
                {
                    Debug.Log("Paila so!");
                }

                Destroy(transform.parent.gameObject);
            }
    }
}
