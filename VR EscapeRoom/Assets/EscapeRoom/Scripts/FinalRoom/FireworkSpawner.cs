using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireworkSpawner : MonoBehaviour
{
    public List<GameObject> fireworkPrefabs;
    public List<Transform> spawnPoints;

    public void SpawnFireworks()
    {
        foreach (Transform point in spawnPoints)
        {
            if (fireworkPrefabs.Count > 0)
            {
                GameObject firework = Instantiate(
                    fireworkPrefabs[Random.Range(0, fireworkPrefabs.Count)],
                    point.position,
                    Quaternion.identity
                );
                firework.GetComponent<VisualEffect>().Play();
            }
        }
    }
}
