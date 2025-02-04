using UnityEngine;

public class UnlockAllTiles : MonoBehaviour
{
    public void MakeAllTilesSafe()
    {
        TileInteraction[] tiles = Object.FindObjectsByType<TileInteraction>(FindObjectsSortMode.None);

        foreach (TileInteraction tile in tiles)
        {
            tile.isSafeTile = true;
        }
    }
}
