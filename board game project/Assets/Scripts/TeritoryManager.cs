﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TeritoryManager : MonoBehaviour
{
    public static TeritoryManager instance;

    public GameObject attackPanel;
    public GameObject scorePanel;
    public GameObject pauseMenuGUI;

    public List<GameObject> teritoryList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        attackPanel.SetActive(false);
        scorePanel.SetActive(true);

        AddTeritoryData();

        if (GameManager.instance.battleHasEnded && GameManager.instance.battleWon)
        {
            TeritoryHandler count = GameObject.Find(GameManager.instance.attackedTeritory).GetComponent<TeritoryHandler>();
            count.teritory.tribe = Teritory.tribes.PLAYER;
            GameManager.instance.wood += count.teritory.woodReward;
            GameManager.instance.stone += count.teritory.stoneReward;
            GameManager.instance.gold += count.teritory.goldReward;
            TintTeritory();
        }
        GameManager.instance.Saving();
    }

    void AddTeritoryData()
    {
        // TODO: random spawn playera
        // TODO: random izabrati plemena
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("Teritory") as GameObject[];
        foreach (GameObject teritory in theArray)
        {
            teritoryList.Add(teritory);
        }

        GameManager.instance.Loading();

        TintTeritory();
        TeritoryDetails();
        //HoverTintTeritory();
    }

    public void TintTeritory()
    {
        for (int i = 0; i < teritoryList.Count; i++)
        {
            TeritoryHandler teritoryHandler = teritoryList[i].GetComponent<TeritoryHandler>();

            if (teritoryHandler.teritory.tribe == Teritory.tribes.ECONOMY)
            {
                teritoryHandler.TintColor(new Color32(233, 214, 30, 50));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.SCIENCE)
            {
                teritoryHandler.TintColor(new Color32(0, 105, 253, 50));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.WARRIOR)
            {
                teritoryHandler.TintColor(new Color32(210, 3, 20, 50));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.PLAYER)
            {
                teritoryHandler.TintColor(new Color32(0, 0, 0, 0));
                //teritoryHandler.TintColor(new Color32(0, 0, 0, 255));
            }
        }
    }

    //public void HoverTintTeritory()
    //{
    //    for (int i = 0; i < teritoryList.Count; i++)
    //    {
    //        TeritoryHandler teritoryHandler = teritoryList[i].GetComponent<TeritoryHandler>();
    //
    //        if (teritoryHandler.teritory.tribe == Teritory.tribes.ECONOMY)
    //        {
    //            teritoryHandler.HoverTintColor(new Color32(233, 214, 30, 255));
    //        }
    //
    //        if (teritoryHandler.teritory.tribe == Teritory.tribes.SCIENCE)
    //        {
    //            teritoryHandler.HoverTintColor(new Color32(0, 105, 253, 255));
    //        }
    //
    //        if (teritoryHandler.teritory.tribe == Teritory.tribes.WARRIOR)
    //        {
    //            teritoryHandler.HoverTintColor(new Color32(210, 3, 20, 255));
    //        }
    //
    //        if (teritoryHandler.teritory.tribe == Teritory.tribes.PLAYER)
    //        {
    //            teritoryHandler.HoverTintColor(new Color32(0, 0, 0, 25));
    //        }
    //    }
    //}

    public void TeritoryDetails()
    {
        for (int i = 0; i < teritoryList.Count; i++)
        {
            TeritoryHandler teritoryHandler = teritoryList[i].GetComponent<TeritoryHandler>();

            if (teritoryHandler.teritory.tribe == Teritory.tribes.ECONOMY)
            {
                teritoryHandler.TribeDetails("Great coin keepers since ancient times.", 20, 20, 60);
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.SCIENCE)
            {
                teritoryHandler.TribeDetails("Never ending thirst for knowledge.", 60, 20, 20);
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.WARRIOR)
            {
                teritoryHandler.TribeDetails("Discipline and courage is what makes Warrior tribe stand out.", 20, 60, 20);
            }
        }
    }

    public void ShowAttackPanel(string description, int woodReward, int stoneReward, int goldReward)
    {
        scorePanel.SetActive(false);
        attackPanel.SetActive(true);
        AttackPanel attackGui = attackPanel.GetComponent<AttackPanel>();
        attackGui.descriptionText.text = description;
        attackGui.woodRewardText.text = "+ " + woodReward.ToString();
        attackGui.stoneRewardText.text = "+ " + stoneReward.ToString();
        attackGui.goldRewardText.text = "+ " + goldReward.ToString();
    }

    public void HideAttackPanel()
    {
        attackPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void ShowScorePanel(int woodAmount, int stoneAmount, int goldAmount, int turn)
    {
        scorePanel.SetActive(true);
        ScorePanel scoreGui = scorePanel.GetComponent<ScorePanel>();
        scoreGui.woodAmount.text = woodAmount.ToString();
        scoreGui.stoneAmount.text = stoneAmount.ToString();
        scoreGui.goldAmount.text = goldAmount.ToString();
        scoreGui.turn.text = "Turn: " + turn.ToString();
    }

    public void HideScorePanel()
    {
        scorePanel.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenuGUI.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenuGUI.SetActive(false);
    }

    public void StartFight()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Battle");
    }

    public void DeleteGame()
    {
        GameManager.instance.DeleteSavedFile();
    }
}
