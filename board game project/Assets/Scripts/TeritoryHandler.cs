using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class TeritoryHandler : MonoBehaviour
{
    public Teritory teritory;
    private SpriteRenderer sprite;
    
    public Color32 oldColor;
    //public Color32 startColor;
    public Color32 hoverColor;

    void Awake() {
        sprite=GetComponent<SpriteRenderer>();
        //sprite.color=startColor;
    }

    void OnMouseEnter() {
        oldColor=sprite.color;
        //sprite.color=hoverColor;
        //HoverTintColor();
        sprite.color=HoverTintColor.hoverColor();
    }

    void OnMouseUpAsButton() {
        print("Pressed");
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
        //sprite.color = color;
    }
}
