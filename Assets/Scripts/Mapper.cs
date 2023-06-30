using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class Mapper : MonoBehaviour
{

    // Tile Data
    [SerializeField] private TextAsset csvTile;
    private int CSVWidth = 6; // nombre de colonne du csv
    private int CSVHeight = 33; // nombre de ligne du csv
    private string[,] tilesData;

    // Reference
    [SerializeField] private UI UI;
    [SerializeField] private Map pMap;
    [SerializeField] private Tile pTile;
    private Map map;


    private enum DataColumn {
        Name,
        Effect_ENG,
        isDestroyable,
        isRecoverable,
        Where, // Entity
        Code
    }


    void Start()
    {
        #region Convert CSV
        // into array of string arrays
        var _data = csvTile.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);
        tilesData = new string[CSVWidth, CSVHeight];


        for (int j = 0; j < CSVHeight; j++) {
            for (int i = 0; i < CSVWidth; i++) {
                tilesData[i, j] = _data[i + j * CSVWidth];
                //Debug.Log(i + ", " + j + " : " + _data[i + j * width]);
            }
        }
        #endregion

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GenerateTile(1);
        }

        if (Input.GetMouseButtonDown(1)) {
            DestroyTile();
        }
    }

    public void GenerateMap(int width, int height ) {
        if (map != null) { map.Destroy(); }
        map = Instantiate(pMap);
        map.Init(width, height);
    }

    public void GenerateTile(int rowIndex) {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int y = 0; y < map.height; y++) {
            for (int x = 0; x < map.width; x++) {
                var cell = map.cells[x, y];
                if (cell.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition)) {
                    var tile = Instantiate(pTile);

                    var name = tilesData[(int)DataColumn.Name, rowIndex];
                    var effect_ENG = tilesData[(int)DataColumn.Effect_ENG, rowIndex];
                    var isDestroyable = tilesData[(int)DataColumn.isDestroyable, rowIndex] == "1";
                    var isRecoverable = tilesData[(int)DataColumn.isRecoverable, rowIndex] == "1";
                    var where = tilesData[(int)DataColumn.Name, rowIndex];
                    var code = tilesData[(int)DataColumn.Name, rowIndex];

                    tile.Init(name, effect_ENG, isDestroyable, isRecoverable, where, code, x, y, UI.GetColor(), cell); // Remplacer 4 par dropdownTile

                    cell.tile = tile;
                }
            }
        }
    }

    public void DestroyTile() {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int y = 0; y < map.height; y++) {
            for (int x = 0; x < map.width; x++) {
                var cell = map.cells[x, y];
                if (cell.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition)) {
                    if (cell.tile != null) { cell.tile.Destroy(); }
                }
            }
        }
    }
}
