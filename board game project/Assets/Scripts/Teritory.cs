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

    [TextArea(15, 20)]
    public string description;
    public int woodReward;
    public int stoneReward;
    public int goldReward;
}
