using UnityEngine;

public class NumbersRoomManager : MonoBehaviour
{
    public GameManager gameManager;
    private bool isRoomCompleted = false;

    public void MarkRoomAsCompleted()
    {
        if (!isRoomCompleted && gameManager != null)
        {
            isRoomCompleted = true;
            gameManager.NumbersRoomCompleted();
        }
    }

    public bool IsRoomCompleted()
    {
        return isRoomCompleted;
    }
}
