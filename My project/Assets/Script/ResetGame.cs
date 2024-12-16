using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private int index = 0;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovement pM = collision.GetComponent<PlayerMovement>();
        if (pM!= null)
        {            
            SceneManager.LoadScene("Reset");
            index++;
            if (index > 3)
            {
                AdDisplayManager.instance.OnUnityAdsAdLoaded("Interstitial_Android");
                index = 0;
            }
        }
    }
}
