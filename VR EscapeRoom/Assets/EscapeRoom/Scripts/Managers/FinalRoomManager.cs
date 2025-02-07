using UnityEngine;

public class FinalRoomManager : MonoBehaviour
{
    public GameManager gameManager;
    public Collider finalDoorTrigger;
    public FireworkSpawner fireworkSpawner;

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

    public void OnFinalButtonPressed()
    {
        if (fireworkSpawner != null)
            fireworkSpawner.SpawnFireworks();
    }
}
