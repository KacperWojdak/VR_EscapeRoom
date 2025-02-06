using UnityEngine;

public class TilesRoomButton : MonoBehaviour
{
    public GameObject tilesParent;
    public GameObject wallTilesHintParent;
    public TilesRoomManager tilesRoomManager;

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

    public void CompleteRoom()
    {
        if (tilesRoomManager != null)
        {
            tilesRoomManager.MarkRoomAsCompleted();
        }
    }
}
