using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI mentalText;
    [SerializeField] TextMeshProUGUI fameText;
    [SerializeField] TextMeshProUGUI penaltiesText;

    [SerializeField] TextMeshProUGUI healthButtonText;
    [SerializeField] TextMeshProUGUI mentalButtonText;
    [SerializeField] TextMeshProUGUI fameButtonText;

    [SerializeField] GameObject cardsPanel;
    [SerializeField] GameObject choicePanel;

    [SerializeField] Button lifeButton;
    [SerializeField] Button mentalButton;
    [SerializeField] Button fameButton;

    bool isLifeActivated;
    bool isMentalActivated;
    bool isFameActivated;
    bool arePanelsSwitched;


    // Start is called before the first frame update
    void Start()
    {
        SetStatsPanel();
        SetCardsPanel();
    }

    private void Update()
    {
        MakeButtonsInteractable();
    }

    //Initializes stats panel texts
    void SetStatsPanel()
    {        
        healthText.text = "Vida: " + GameManager.Instance.playerLife;
        mentalText.text = "Salud Mental: " + GameManager.Instance.playerMentalHealth;
        fameText.text = "Fama: " + GameManager.Instance.playerFame;
        penaltiesText.text = "Penalizaciones: " + GameManager.Instance.playerPenalties;
    }

    //Initializes cards panel texts
    public void SetCardsPanel()
    {        
        healthButtonText.text = GameManager.Instance.healthCards.ToString();
        mentalButtonText.text = GameManager.Instance.mentalCards.ToString();
        fameButtonText.text = GameManager.Instance.fameCards.ToString();
    }

    public void AddLifeOnClick()
    {
        SwitchPanels();
        isLifeActivated = true;
    }

    public void AddMentalHealthOnClick()
    {
        SwitchPanels();
        isMentalActivated = true;
    }

    public void AddFameOnClick()
    {
        SwitchPanels();
        isFameActivated = true;
    }

    public void AddStatsToPlayerOnClick()
    {
        if(isLifeActivated == true)
        {
            GameManager.Instance.healthCards--;
            GameManager.Instance.playerLife++;
        }
        else if(isMentalActivated == true)
        {
            GameManager.Instance.mentalCards--;
            GameManager.Instance.playerMentalHealth++;
        }
        else if(isFameActivated == true)
        {
            GameManager.Instance.fameCards--;
            GameManager.Instance.playerFame++;
        }

        SetStatsPanel();
        SetCardsPanel();
        SwitchPanels();
    }

    public void SwitchPanels()
    {
        if (!arePanelsSwitched)
        {
            cardsPanel.gameObject.SetActive(false);
            choicePanel.gameObject.SetActive(true);
        }
        else if (arePanelsSwitched)
        {
            cardsPanel.gameObject.SetActive(true);
            choicePanel.gameObject.SetActive(false);
            isLifeActivated = false;
            isMentalActivated = false;
            isFameActivated = false;
        }

        arePanelsSwitched = !arePanelsSwitched;
    }

    void MakeButtonsInteractable()
    {
        if (GameManager.Instance.healthCards > 0)
        {
            lifeButton.interactable = true;
        }
        else if (GameManager.Instance.healthCards == 0)
        {
            lifeButton.interactable = false;
        }

        if (GameManager.Instance.mentalCards > 0)
        {
            mentalButton.interactable = true;
        }
        else if (GameManager.Instance.mentalCards == 0)
        {
            mentalButton.interactable = false;
        }

        if (GameManager.Instance.fameCards > 0)
        {
            fameButton.interactable = true;
        }
        else if (GameManager.Instance.fameCards == 0)
        {
            fameButton.interactable = false;
        }
    }

    public void ChooseCard()
    {
        int number = Random.Range(0, 3);
        switch (number)
        {
            case 0:
                GameManager.Instance.healthCards++;
                break;
            case 1:
                GameManager.Instance.mentalCards++;
                break;
            case 2:
                GameManager.Instance.fameCards++;
                break;
        }

        SetCardsPanel();
    }
}
