using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour {

    private new string name;
    private string effect_ENG;
    private bool isDestroyable;
    private bool isRecoverable;
    private string where; // Entity
    private string code;

    private int x, y;
    private Color color;
    private Cell cell;



    public void Init(string name, string effect_ENG, bool isDestroyable, bool isRecoverable, string where, string code, int x, int y, Color color, Cell cell) {
        this.name = name;
        this.effect_ENG = effect_ENG;
        this.isDestroyable = isDestroyable;
        this.isRecoverable = isRecoverable;
        this.where = where;
        this.code = code;

        this.x = x;
        this.y = y;
        this.color = color;
        GetComponent<SpriteRenderer>().color = color;
        this.cell = cell;

        transform.position = cell.transform.position;
    }

    public void Destroy() { 
        Destroy(gameObject);
    }
}
