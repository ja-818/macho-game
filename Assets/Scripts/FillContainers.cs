using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillContainers : MonoBehaviour
{
    [SerializeField] private List<GameObject> containersList;
    private int number1;
    private int number2;
    private int number3;
    private int totalContainers;

    // Start is called before the first frame update
    void Start()
    {
        totalContainers = containersList.Count;
        AssignCardsToContainers();
    }
    void AssignCardsToContainers()
    {
        PickThreeRandomDifferentNumbers();

        //Assignes 1 challenge and 2 cards to different containers
        containersList[number1].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasChallenge = true;
        containersList[number2].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasCard = true;
        containersList[number3].gameObject.transform.GetChild(0).GetComponent<ContainersBehaviour>().hasCard = true;
    }

    void PickThreeRandomDifferentNumbers()
    {
        //Picks 3 random different numbers from the total of the containers

        number1 = Random.Range(0, totalContainers);
        number2 = Random.Range(0, totalContainers);

        while (number1 == number2)
        {
            number2 = Random.Range(0, totalContainers);
        }

        number3 = Random.Range(0, totalContainers);

        while (number1 == number3 || number2 == number3)
        {
            number3 = Random.Range(0, totalContainers);
        }
    }
}
