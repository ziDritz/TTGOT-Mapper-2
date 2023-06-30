using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour {
    public int width { get; private set; }
    public int height { get; private set; }

    [SerializeField] Cell pCell;
    public Cell[,] cells { get; private set; }


    public void Init (int width, int height) {

        this.width = width;
        this.height = height;

        // Position map depending its size
        transform.position -= new Vector3(width / 2, height / 2);

        // Instanciate Cells
        cells = new Cell[width, height];

        for (int x = 0;  x < width; x++) {
            for (int y = 0; y < height; y++) {
                var cell = Instantiate(pCell);
                cell.Init(this, x, y);
                cells[x, y] = cell;
            }
        }
    }

    public void Reset () {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var cell = cells[x, y];
                cell.Destroy();
            }
        }
    }

    public void Destroy () {
        Reset();
        Destroy(gameObject);
    }
}
