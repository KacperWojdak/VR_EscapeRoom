using System.Collections.Generic;
using UnityEngine;

public class SafePathGenerator : MonoBehaviour
{
    public Transform tileParent;
    public int gridSizeX = 7;
    public int gridSizeZ = 7;
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
                break;
            }

            int x = index % gridSizeX;
            int z = index / gridSizeX;

            if (tile.TryGetComponent<TileInteraction>(out var tileScript))
            {
                tileGrid[x, z] = tileScript;
            }
            index++;
        }
    }

    void GenerateSafePath()
    {
        safePath = new List<Vector2Int>();

        int startX = Random.Range(0, gridSizeX);
        int endX = Random.Range(0, gridSizeX);

        int x = startX;
        int z = 0;

        safePath.Add(new Vector2Int(x, z));
        tileGrid[x, z].isSafeTile = true;

        while (x != endX || z < gridSizeZ - 1)
        {
            if (z < gridSizeZ - 1 && (x == endX || Random.value > 0.5f))
            {
                z++;
            }
            else if (x < endX)
            {
                x++;
            }
            else if (x > endX)
            {
                x--;
            }

            safePath.Add(new Vector2Int(x, z));
            tileGrid[x, z].isSafeTile = true;
        }
    }
}
