using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI mentalText;
    [SerializeField] TextMeshProUGUI fameText;
    [SerializeField] TextMeshProUGUI penaltiesText;

    [SerializeField] TextMeshProUGUI healthButtonText;
    [SerializeField] TextMeshProUGUI mentalButtonText;
    [SerializeField] TextMeshProUGUI fameButtonText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SetStatsPanel();
        SetCardsPanel();
    }

    void SetStatsPanel()
    {
        //Initializes stats panel texts
        healthText.text = "Vida: " + gameManager.playerLife;
        mentalText.text = "Salud Mental: " + gameManager.playerMentalHealth;
        fameText.text = "Fama: " + gameManager.playerFame;
        penaltiesText.text = "Penalizaciones: " + gameManager.playerPenalties;
    }

    public void SetCardsPanel()
    {
        //Initializes cards panel texts
        healthButtonText.text = gameManager.healthCards.ToString();
        mentalButtonText.text = gameManager.mentalCards.ToString();
        fameButtonText.text = gameManager.fameCards.ToString();
    }

    public void AddLifeOnClick()
    {
        if(gameManager.healthCards > 0)
        {
            gameManager.healthCards--;
            gameManager.playerLife++;
            SetStatsPanel();
            SetCardsPanel();
        }
    }

    public void AddMentalHealthOnClick()
    {
        if(gameManager.mentalCards > 0)
        {
            gameManager.mentalCards--;
            gameManager.playerMentalHealth++;
            SetStatsPanel();
            SetCardsPanel();
        }
    }

    public void AddFameOnClick()
    {
        if (gameManager.fameCards > 0)
        {
            gameManager.fameCards--;
            gameManager.playerFame++;
            SetStatsPanel();
            SetCardsPanel();
        }
        
    }

}
