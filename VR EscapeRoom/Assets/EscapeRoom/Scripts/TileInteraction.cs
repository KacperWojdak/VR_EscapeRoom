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
}
