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
    public GameObject textObject;

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

            if (musicManager != null)
            {
                musicManager.FadeOutMusic(2f);
            }

            if (textObject != null)
            {
                textObject.SetActive(true);
                textObject.transform.localScale = Vector3.zero;

                LeanTween.scale(textObject, Vector3.one, 1f).setEase(LeanTweenType.easeOutBack);
            }

            StartCoroutine(FireworkLoop());
        }
    }

    private IEnumerator FireworkLoop()
    {

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
