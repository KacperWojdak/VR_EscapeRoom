using UnityEngine;

public class TilesRoomManager : MonoBehaviour
{
    public GameManager gameManager;
    private bool isRoomCompleted = false;

    public void MarkRoomAsCompleted()
    {
        if (!isRoomCompleted && gameManager != null)
        {
            isRoomCompleted = true;
            gameManager.TilesRoomCompleted();
        }
    }

    public bool IsRoomCompleted()
    {
        return isRoomCompleted;
    }
}
