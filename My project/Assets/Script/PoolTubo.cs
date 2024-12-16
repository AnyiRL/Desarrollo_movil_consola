using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTubo : MonoBehaviour
{
    public GameObjectPool tuboPool;
    public float maxTime;
    private float currentTime, times;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        times += Time.deltaTime;
        if (currentTime>maxTime)
        {            
            float valor = Random.Range(-2, 3);
            //float valorS = 2;
            GameObject obj = tuboPool.GimmeInactiveGameObject();
            currentTime = 0;
            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                obj.transform.position = (new Vector3 (13, valor, 0));
                obj.GetComponent<Tubos>().SetDirection(-Vector3.right);
                //if (times > 20)
                //{
                //    maxTime -= 1;
                //    times = 0;
                //    obj.GetComponent<Tubos>().SetSpeed(valorS);
                //    times = 0;
                //    valorS += 1;
                //}
            }
        }
    }
}
