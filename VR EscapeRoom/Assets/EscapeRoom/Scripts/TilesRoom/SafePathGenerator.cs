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

        // Losowy kafelek startowy w rzêdzie 0
        int startX = Random.Range(0, gridSizeX);

        // Losowy kafelek koñcowy w rzêdzie 6
        int endX = Random.Range(0, gridSizeX);

        int x = startX;
        int z = 0;

        safePath.Add(new Vector2Int(x, z));
        tileGrid[x, z].isSafeTile = true;

        // Generowanie œcie¿ki od startX w (0,x) do endX w (6,x)
        while (x != endX || z < gridSizeZ - 1)
        {
            if (z < gridSizeZ - 1 && (x == endX || Random.value > 0.5f))
            {
                z++; // Ruch w dó³
            }
            else if (x < endX)
            {
                x++; // Ruch w prawo
            }
            else if (x > endX)
            {
                x--; // Ruch w lewo
            }

            safePath.Add(new Vector2Int(x, z));
            tileGrid[x, z].isSafeTile = true;
        }

        Debug.Log($"Œcie¿ka wygenerowana poprawnie od (0,{startX}) do (6,{endX}).");
    }
}
