using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Teritory
{
    public string name;

    public enum tribes
    {
        WARRIOR,
        SCIENCE,
        ECONOMY,
        PLAYER
    }

    public tribes tribe;
    public int moneyReward;
    public int experienceReward;

}
