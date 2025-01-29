using System.Collections.Generic;
using UnityEngine;

public class SafePathGenerator : MonoBehaviour
{
    public Transform tileParent;
    public int gridSizeX = 5;
    public int gridSizeZ = 5;
    public TileInteraction[,] tileGrid;

    public List<Vector2Int> safePath;

    void Start()
    {
        InitializeTileGrid();
        GenerateSafePath();
    }

    void InitializeTileGrid()
    {
        tileGrid = new TileInteraction[gridSizeX, gridSizeZ];
        int index = 0;

        foreach (Transform tile in tileParent)
        {
            if (index >= gridSizeX * gridSizeZ)
            {
                Debug.LogWarning("Too many tiles for the specified grid size.");
                break;
            }

            int x = index % gridSizeX;
            int z = index / gridSizeX;

            if (tile.TryGetComponent<TileInteraction>(out var tileScript))
            {
                tileGrid[x, z] = tileScript;
                Debug.Log($"Tile assigned at grid position: ({x}, {z})");
            }
            else
            {
                Debug.LogWarning($"Tile at index {index} is missing the TileInteraction component.");
            }
            index++;
        }
    }

    void GenerateSafePath()
    {
        safePath = new List<Vector2Int>();
        int x = 0, z = 0;

        while (x < gridSizeX - 1 || z < gridSizeZ - 1)
        {
            safePath.Add(new Vector2Int(x, z));
            tileGrid[x, z].isSafeTile = true;

            if (x < gridSizeX - 1 && (z == gridSizeZ - 1 || Random.value > 0.5f))
            {
                x++;
            }
            else if (z < gridSizeZ - 1)
            {
                z++;
            }
        }

        safePath.Add(new Vector2Int(x, z));
        tileGrid[x, z].isSafeTile = true;
    }
}
