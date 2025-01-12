using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public AudioClip ResetClip;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovement pM = collision.GetComponent<PlayerMovement>();
        if (pM!= null)
        {           
            AudioManager.instance.PlayAudio(ResetClip, "resetSound");          
        }
    }
}
