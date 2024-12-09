using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTubo : MonoBehaviour
{
    public GameObjectPool tuboPool;
    public float maxTime = 5;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime>maxTime)
        {
            float valor = Random.Range(-1, 2);
            GameObject obj = tuboPool.GimmeInactiveGameObject();

            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                obj.transform.position = transform.position;
                obj.GetComponent<Tubos>().SetDirection(-transform.position);
            }
        }
    }
}
