using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{
    public GameObject particlePrefab;
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDARLONE //del procesador que se ejecuta antes de compilar   CONDITIONAL COMBINATION
        // PC
        if (Input.GetMouseButtonDown(0))
        {
            InstanceParticle(Input.mousePosition, Color.green);
        }
#elif UNITY_ANDROID

        // Android
        foreach (Touch touch in Input.touches) //por cada toque en todos los toques que haya en pantalla
        {
            if (touch.phase == TouchPhase.Began)  //si es el primer toque de la pantalla
            {
                InstanceParticle(touch.position, Color.blue);
            }
        }
#endif
    }

    

    void InstanceParticle(Vector3 screenCoords, Color color)
    {
        screenCoords.z = 10;                          //para alejarlo 10 unidades de la camara
        Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords);        //pasa la posicion de la pantalla a la del juego
        GameObject particleClone = Instantiate(particlePrefab, gameCoords, Quaternion.identity); 
        particleClone.GetComponent<Renderer>().material.color = color;
    }
}
