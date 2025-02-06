using UnityEngine;

public class FinalRoomManager : MonoBehaviour
{
    public GameManager gameManager;
    public Collider finalDoorTrigger;

    private bool isFinalRoomUnlocked = false;

    private void Update()
    {
        if (!isFinalRoomUnlocked && gameManager.AllRoomsCompleted())
        {
            UnlockFinalRoom();
        }
    }

    private void UnlockFinalRoom()
    {
        isFinalRoomUnlocked = true;
        if (finalDoorTrigger != null)
        {
            finalDoorTrigger.enabled = true;
        }
    }
}
