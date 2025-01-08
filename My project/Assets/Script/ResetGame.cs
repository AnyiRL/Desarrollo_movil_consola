using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private int valor = 1;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovement pM = collision.GetComponent<PlayerMovement>();
        if (pM!= null)
        {
            GameManager.instance.Dead(valor);
            SceneManager.LoadScene("Reset");                     
        }
    }
}
