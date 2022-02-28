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
        
        //Initializes stats panel texts
        healthText.text = "Vida: " + gameManager.playerLife;
        mentalText.text = "Salud Mental: " + gameManager.playerMentalHealth;
        fameText.text = "Fama: " + gameManager.playerFame;
        penaltiesText.text = "Penalizaciones: " + gameManager.playerPenalties;

        //Initializes cards panel texts
        healthButtonText.text = gameManager.healthCards.ToString();
        mentalButtonText.text = gameManager.mentalCards.ToString();
        fameButtonText.text = gameManager.fameCards.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
