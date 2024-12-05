using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int valor = 1;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovement PMComponent = collision.gameObject.GetComponent<PlayerMovement>();

        if (PMComponent != null)
        {
            GameManager.instance.AddPoints(valor);
        }

    }
}
