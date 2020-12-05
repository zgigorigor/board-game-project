using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeritoryManager : MonoBehaviour
{
    public static TeritoryManager instance;

    public GameObject attackPanel;

    public List<GameObject> teritoryList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        attackPanel.SetActive(false);

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

    public void ShowAttackPanel(string description, int woodReward, int stoneReward, int goldReward)
    {
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.descriptionText.text = description;
        gui.woodRewardText.text = "+ " + woodReward.ToString();
        gui.stoneRewardText.text = "+ " + stoneReward.ToString();
        gui.goldRewardText.text = "+ " + goldReward.ToString();
    }

    public void HideAttackPanel()
    {
        attackPanel.SetActive(false);
    }
}
