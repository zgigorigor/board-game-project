using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class TeritoryHandler : MonoBehaviour
{
    public Teritory teritory;
    private SpriteRenderer sprite;
    
    public Color32 oldColor;
    public Color32 hoverColor;

    void Awake() {
        sprite=GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter() {
        oldColor=sprite.color;
        sprite.color=hoverColor;
    }

    void OnMouseUpAsButton() {
        //print("Pressed");
        ShowGUI();
    }

    void OnMouseExit() {
        sprite.color=oldColor;
    }

    void OnDrawGizmos() {
        teritory.name = name;  
        this.tag = "Teritory";  
    }

    public void TintColor(Color32 color){
        sprite.color=color;
    }

    public void HoverTintColor(Color32 color){
        hoverColor = color;
    }

    void ShowGUI()
    {
        TeritoryManager.instance.ShowAttackPanel(teritory.description, teritory.woodReward, teritory.stoneReward, teritory.goldReward);
    }
}
