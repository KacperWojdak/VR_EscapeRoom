using UnityEngine;

public class RiddlersRoomManager : MonoBehaviour
{
    public RiddlePedestal[] pedestals;
    public GameManager gameManager;

    private bool roomCompleted = false;

    void Update()
    {
        if (!roomCompleted && AreAllRiddlesSolved())
        {
            roomCompleted = true;
            NotifyGameManager();
        }
    }

    private bool AreAllRiddlesSolved()
    {
        foreach (var pedestal in pedestals)
        {
            if (!pedestal.hasCorrectItem)
            {
                return false;
            }
        }
        return true;
    }

    private void NotifyGameManager()
    {
        if (gameManager != null)
        {
            gameManager.RiddlersRoomCompleted();
        }
    }
}
