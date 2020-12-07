using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class TeritoryHandler : MonoBehaviour
{
    public Teritory teritory;
    private SpriteRenderer sprite;

    private Color32 oldColor;
    private Color32 hoverColor;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        oldColor = sprite.color;
        if (teritory.tribe == Teritory.tribes.PLAYER)
        {
            hoverColor = oldColor;
        }
        else
        {
            hoverColor = new Color32(oldColor.r, oldColor.g, oldColor.b, 255);
        }
        sprite.color = hoverColor;
    }

    void OnMouseUpAsButton()
    {
        //print("Pressed");
        if (teritory.tribe != Teritory.tribes.PLAYER)
        {
            ShowGUI();
        }
    }

    void OnMouseExit()
    {
        sprite.color = oldColor;
    }

    void OnDrawGizmos()
    {
        teritory.name = name;
        this.tag = "Teritory";
    }

    public void TintColor(Color32 color)
    {
        sprite.color = color;
    }

    //public void HoverTintColor(Color32 color){
    //    hoverColor = color;
    //}

    void ShowGUI()
    {
        //TeritoryManager.instance.ShowAttackPanel(teritory.description, teritory.woodReward, teritory.stoneReward, teritory.goldReward);
        TeritoryManager.instance.ShowAttackPanel("This teritory is owned by the " + teritory.tribe.ToString() + " tribe. Are you sure you want to attack them?", teritory.woodReward, teritory.stoneReward, teritory.goldReward);
        GameManager.instance.attackedTeritory = teritory.name;
        GameManager.instance.battleHasEnded = false;
        GameManager.instance.battleWon = false;
    }
}
