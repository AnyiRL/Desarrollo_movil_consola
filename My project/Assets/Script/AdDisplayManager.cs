using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdDisplayManager instance;
    public string unityAdsID;
    public int androidID, appleID;
    public string adTpye = "Banner_Android";
    public bool testMode = true;  //para que no nos denuncien siempre en true
   
    public void OnUnityAdsAdLoaded(string placementId)  //cuando haya qu ecargar anuncio
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)  //cuando da error en cargar el anuncio
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)  //Ejecuta la lógica para un usuario que hace clic en un anuncio mientras se muestra.
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)  //Ejecuta la lógica para que el anuncio finalice en su totalidad.
    {
        SceneManager.LoadScene("Menu");      //se termina el anuncio y se cambia a la escena indicada
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)  //cuando no se ha conseguido completar el anuncio
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)  //Ejecuta la lógica para que un anuncio se muestre correctamente.
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!Advertisement.isInitialized)
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID
        {
            Advertisement.Initialize(androidID.ToString(), testMode);   //inicializa los anuncios
            
#elif UNITY_IOS
            Advertisement.Load(appleID.ToString(), testMode);
            
#endif
        }
    }

    public void ShowAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(adTpye);
            Advertisement.Show(adTpye);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
// PROBLEMA DEL DIAMANTE
//A PADRE
//BC HEREDA 
//D HEREDA BC Y DOBLE A, PARA RESOLVERLO HAY QUE INIDCAR CUAL TIENE LA PRIORIDAD EN C* lo han quitado directamente, poniendo interfaces