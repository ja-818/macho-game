using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    public void AlternativaOnClick()
    {
        GameManager.Instance.playerFame--;
        GameManager.Instance.isChallengeFound = false;
        SceneManager.LoadScene(0);
    }

    public void SeaMachoOnClick()
    {
        int number;
        number = Random.Range(0, 2);
        switch (number)
        {
            case 0:
                GameManager.Instance.playerFame += 2;
                GameManager.Instance.playerLife -= 1;
                break;
            case 1:
                GameManager.Instance.playerFame -= 2;
                GameManager.Instance.playerLife -= 1;
                break;
        }
        GameManager.Instance.isChallengeFound = false;
        SceneManager.LoadScene(0);
    }
}
