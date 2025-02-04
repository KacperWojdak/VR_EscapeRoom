using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Light> riddleRoomLights;
    public List<Light> numbersRoomLights;
    public List<Light> tilesRoomLights;

    public RiddlePedestal[] pedestals;
    public CheckNumbers numberChecker;
    public UnlockAllTiles tileUnlocker;

    private bool riddleRoomComplete = false;
    private bool numbersRoomComplete = false;
    private bool tilesRoomComplete = false;

    private void Update()
    {
        CheckRiddleRoom();
        CheckNumbersRoom();
        CheckTilesRoom();
    }

    private void CheckRiddleRoom()
    {
        if (!riddleRoomComplete)
        {
            bool allCorrect = true;

            foreach (var pedestal in pedestals)
            {
                if (!pedestal.HasCorrectItem)
                {
                    allCorrect = false;
                    break;
                }
            }

            if (allCorrect)
            {
                riddleRoomComplete = true;
                UpdateLights(riddleRoomLights, Color.green);
            }
        }
    }

    private void CheckNumbersRoom()
    {
        if (!numbersRoomComplete && numberChecker.IsCombinationCorrect)
        {
            numbersRoomComplete = true;
            UpdateLights(numbersRoomLights, Color.green);
        }
    }

    private void CheckTilesRoom()
    {
        if (!tilesRoomComplete && tileUnlocker != null)
        {
            tilesRoomComplete = true;
            UpdateLights(tilesRoomLights, Color.green);
        }
    }

    private void UpdateLights(List<Light> roomLights, Color color)
    {
        foreach (var roomLight in roomLights)
        {
            if (roomLight != null)
            {
                LeanTween.value(gameObject, roomLight.color, color, 0.5f).setOnUpdate((Color updatedColor) =>
                {
                    roomLight.color = updatedColor;
                });
            }
        }
    }
}
