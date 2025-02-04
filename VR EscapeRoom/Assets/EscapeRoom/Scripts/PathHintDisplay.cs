using UnityEngine;
using System.Collections.Generic;

public class PathHintDisplay : MonoBehaviour
{
    public SafePathGenerator pathGenerator;
    public Transform hintParent;
    public GameObject safeEffectPrefab;
    public GameObject dangerEffectPrefab;

    private List<Renderer> hintTiles = new();
    private List<GameObject> activeEffects = new();

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
        foreach (var effect in activeEffects)
        {
            Destroy(effect);
        }
        activeEffects.Clear();

        for (int z = 0; z < pathGenerator.gridSizeZ; z++)
        {
            for (int x = 0; x < pathGenerator.gridSizeX; x++)
            {
                int tileIndex = z * pathGenerator.gridSizeX + x;

                if (tileIndex < hintTiles.Count && pathGenerator.tileGrid[x, z] != null)
                {
                    bool isSafe = pathGenerator.tileGrid[x, z].isSafeTile;

                    GameObject effectPrefab = isSafe ? safeEffectPrefab : dangerEffectPrefab;
                    if (effectPrefab != null)
                    {
                        Vector3 effectPosition = hintTiles[tileIndex].transform.position;
                        effectPosition.y += 0.1f;

                        var effectInstance = Instantiate(effectPrefab, effectPosition, Quaternion.identity, hintParent);
                        activeEffects.Add(effectInstance);
                    }
                }
            }
        }
    }
}
