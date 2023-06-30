using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cell : MonoBehaviour
{

    private Map map;
    private int x, y;
    public Tile tile;


    public void Init(Map map, int x, int y) {
        this.map = map;
        transform.position = map.transform.position + new Vector3(x, y);

        this.x = x; 
        this.y = y;
    }

    public void Destroy() { 
        if (tile != null) { tile.Destroy(); }
        Destroy(gameObject);
    }


}
