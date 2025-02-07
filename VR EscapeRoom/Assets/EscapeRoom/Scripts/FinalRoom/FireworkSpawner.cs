using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireworkSpawner : MonoBehaviour
{
    public List<GameObject> fireworkPrefabs;
    public List<Transform> spawnPoints;
    public MusicManager musicManager;
    public float fireworkInterval = 4.5f;
    public GameObject fireworkButton;

    private bool isFireworkShowActive = false;

    public void StartFireworkShow()
    {
        if (!isFireworkShowActive)
        {
            isFireworkShowActive = true;

            if (fireworkButton != null)
            {
                fireworkButton.SetActive(false);
            }

            StartCoroutine(FireworkLoop());
        }
    }

    private IEnumerator FireworkLoop()
    {
        if (musicManager != null)
        {
            musicManager.MuteBackgroundMusic();
        }

        while (isFireworkShowActive)
        {
            SpawnFireworks();
            yield return new WaitForSeconds(fireworkInterval);
        }
    }

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
