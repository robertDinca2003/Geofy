using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
 
public class AdsInitializer : MonoBehaviour,IUnityAdsShowListener, IUnityAdsInitializationListener, IUnityAdsLoadListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    //public bool reward = false ; 
    //[SerializeField] InterstatialAdsButton interstitialAds;
 
    //public void adreward(){reward = true;}
    void Awake()
    {
        if(Advertisement.isInitialized)
        {
               // LoadInterstatialAd();
        }
        else
        InitializeAds();
    }
 
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void LoadInterstatialAd()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        Advertisement.Load("Interstitial_Android",this);
        else
        Advertisement.Load("Interstitial_iOS",this);
    }

    public void LoadRewardedAd()
    {
        
       
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId,this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete "+showCompletionState);
        
    }
}