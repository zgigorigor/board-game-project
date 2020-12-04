using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeritoryManager : MonoBehaviour
{
    public static TeritoryManager instance;

    public List<GameObject> teritoryList = new List<GameObject>();
    public GameObject attackPanel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        attackPanel.SetActive(false);
        AddTeritoryData();
    }

    void AddTeritoryData()
    {
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("Teritory") as GameObject[];
        foreach (GameObject teritory in theArray)
        {
            teritoryList.Add(teritory);
        }

        TintTeritory();
        HoverTintTeritory();
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
                teritoryHandler.TintColor(new Color32(0, 0, 0, 255));
            }
        }
    }

    public void HoverTintTeritory()
    {
        for (int i = 0; i < teritoryList.Count; i++)
        {
            TeritoryHandler teritoryHandler = teritoryList[i].GetComponent<TeritoryHandler>();

            if (teritoryHandler.teritory.tribe == Teritory.tribes.ECONOMY)
            {
                teritoryHandler.HoverTintColor(new Color32(233, 214, 30, 255));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.SCIENCE)
            {
                teritoryHandler.HoverTintColor(new Color32(0, 105, 253, 255));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.WARRIOR)
            {
                teritoryHandler.HoverTintColor(new Color32(210, 3, 20, 255));
            }

            if (teritoryHandler.teritory.tribe == Teritory.tribes.PLAYER)
            {
                teritoryHandler.HoverTintColor(new Color32(0, 0, 0, 25));
            }
        }
    }

    public void ShowAttackPanel(string description, int moneyReward, int experienceReward){
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.descriptionText.text = description;
        gui.moneyRewardText.text = moneyReward.ToString();
        gui.experienceRewardText.text = experienceReward.ToString();
    }

    public void HideAttackPanel(){
        attackPanel.SetActive(false);
    }
}
