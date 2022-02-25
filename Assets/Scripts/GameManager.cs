using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> containersList;
    
    private int number1;
    private int number2;
    private int number3;

    public bool isChallengeFound;

    // Start is called before the first frame update
    void Start()
    {
        PickThreeRandomDifferentNumbers();
        AssignCardsToContainers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickThreeRandomDifferentNumbers()
    {
        number1 = Random.Range(0, 9);
        number2 = Random.Range(0, 9);

        while (number1 == number2)
        {
            number2 = Random.Range(0, 9);
        }

        number3 = Random.Range(0, 9);

        while (number1 == number3 || number2 == number3)
        {
            number3 = Random.Range(0, 9);
        }
    }

    void AssignCardsToContainers()
    {
        containersList[number1].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasChallenge = true;
        containersList[number2].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasCard = true;
        containersList[number3].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasCard = true;
    }
}
