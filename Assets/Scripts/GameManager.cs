using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //VARIABLES
    public int playerLife = 5;
    public int playerMentalHealth = 5;
    public int playerFame = 1;
    public int playerPenalties = 0;

    public int healthCards = 0;
    public int mentalCards = 0;
    public int fameCards = 0;

    public bool isChallengeFound;


    //REFERENCES
    private StatsUIManager statsUIManagerScript;

    private void Start()
    {
        statsUIManagerScript = GameObject.Find("Canvas").GetComponent<StatsUIManager>();
    }

    public void ChooseCard()
    {
        int number = Random.Range(0, 3);
        switch (number)
        {
            case 0:
                healthCards++;
                break;
            case 1:
                mentalCards++;
                break;
            case 2:
                fameCards++;
                break;
        }

        statsUIManagerScript.SetCardsPanel();
    }
}
