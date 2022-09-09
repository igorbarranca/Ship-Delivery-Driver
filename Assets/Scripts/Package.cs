using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    [SerializeField] float timeForDeactivating = 0.5f;
    [SerializeField] List<Transform> spawnPoints;

    public void PackageCollected()
    {
        Debug.Log("Hai preso un package " + gameObject.name);
        StartCoroutine(DeactivateObject());
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(timeForDeactivating);

        gameObject.SetActive(false);
    }

    public void RelocatePackage()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        transform.position = spawnPoints[randomIndex].position;
    }
}
