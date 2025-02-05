using UnityEngine;

public class TileInteraction : MonoBehaviour
{
    public bool isSafeTile;
    public Transform playerStartPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSafeTile)
            {
                other.transform.position = playerStartPosition.position;
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (player.TryGetComponent<CharacterController>(out var characterController))
        {
            characterController.enabled = false;
            player.transform.position = playerStartPosition.position;
            characterController.enabled = true;
        }
        else
        {
            player.transform.position = playerStartPosition.position;
        }
    }
}
