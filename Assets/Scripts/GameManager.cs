using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLife = 5;
    public int playerMentalHealth = 5;
    public int playerFame = 1;
    public int playerPenalties = 0;

    public int healthCards = 0;
    public int mentalCards = 0;
    public int fameCards = 0;

    public bool isChallengeFound;

    // Start is called before the first frame update
    void Start()
    {
    }
}
