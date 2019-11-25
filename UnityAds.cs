using UnityEngine.Advertisements;
using UnityEngine;
using System.Collections;

public class UnityAds : MonoBehaviour
{
    void Start()
    {
        Advertisement.Initialize("33675", true);

        StartCoroutine(ShowAdWhenReady());
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }
}
