using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour, IUnityAdsListener
{
    private string playstoreGameId = "3688147";
    private string appstoreGameId = "3688146";

    private string inad = "video";
    private string rewardedAd = "rewardedVideo";

    private bool isTestAd = false;

    private Statistics stats;
    public GameObject music;
    void Start()
    {
        stats = Camera.main.GetComponent<Statistics>();
        Advertisement.AddListener(this);
        InitializeAd();
    }
    private void InitializeAd()
    {
         Advertisement.Initialize(playstoreGameId, isTestAd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        music.SetActive(false);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedAd)
                {
                    stats.coins += 2 * (stats.potatoPrice * stats.potatoes);
                    stats.potatoes = 0;
                }
                break;
        }
    }
    public void PlayRewardAd()
    {
        if (!Advertisement.IsReady(rewardedAd)) { return; }
        Advertisement.Show(rewardedAd);
    }
}
