using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //VARIABLES
    public int playerLife = 5;
    public int playerMentalHealth = 5;
    public int playerFame = 1;
    public int playerPenalties = 0;

    public int healthCards = 0;
    public int mentalCards = 0;
    public int fameCards = 0;

    public bool isChallengeFound;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        ChangeFamePerMentalHealth();
    }


    //If fame gets below 0, substracts that to mental health and sets fame to 0
    void ChangeFamePerMentalHealth()
    {
        if (playerFame < 0)
        {
            playerMentalHealth = playerMentalHealth + playerFame;
            playerFame = 0;
        }
    }
}
