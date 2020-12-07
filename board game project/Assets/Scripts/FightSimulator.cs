using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class FightSimulator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        yield return new WaitForSeconds(2);
        int num = Random.Range(0, 2);

        if (num == 0)
        {
            GameManager.instance.battleWon = false;
        }
        else
        {
            GameManager.instance.battleWon = true;
        }

        GameManager.instance.battleHasEnded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
