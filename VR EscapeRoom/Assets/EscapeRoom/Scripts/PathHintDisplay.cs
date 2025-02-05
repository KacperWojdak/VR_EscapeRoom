using UnityEngine;
using System.Collections.Generic;

public class PathHintDisplay : MonoBehaviour
{
    public SafePathGenerator pathGenerator;
    public Transform hintParent;
    public Material safeMaterial;
    public Material dangerMaterial;

    private List<Renderer> hintTiles = new();

    void Start()
    {
        if (hintParent == null)
        {
            Debug.LogError("Hint parent is not assigned.");
            return;
        }

        foreach (Transform hintTile in hintParent)
        {
            if (hintTile.TryGetComponent<Renderer>(out var tileRenderer))
            {
                hintTiles.Add(tileRenderer);
            }
        }

        UpdateHint();
    }

    void UpdateHint()
    {
        for (int z = 0; z < pathGenerator.gridSizeZ; z++)
        {
            for (int x = 0; x < pathGenerator.gridSizeX; x++)
            {
                int tileIndex = z * pathGenerator.gridSizeX + x;

                if (tileIndex < hintTiles.Count && pathGenerator.tileGrid[x, z] != null)
                {
                    bool isSafe = pathGenerator.tileGrid[x, z].isSafeTile;
                    Material targetMaterial = isSafe ? safeMaterial : dangerMaterial;
                    hintTiles[tileIndex].material = targetMaterial;
                }
            }
        }
    }
}
