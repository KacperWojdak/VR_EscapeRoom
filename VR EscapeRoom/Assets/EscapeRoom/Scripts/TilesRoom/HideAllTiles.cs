using UnityEngine;

public class HideAllTiles : MonoBehaviour
{
    public GameObject tilesParent;
    public GameObject wallTilesHintParent;

    public void MakeAllTilesSafe()
    {
        if (tilesParent != null)
        {
            foreach (Transform child in tilesParent.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        if (wallTilesHintParent != null)
        {
            foreach (Transform child in wallTilesHintParent.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
