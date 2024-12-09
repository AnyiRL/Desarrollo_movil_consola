using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObjectPool bulletPool;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            GameObject obj = bulletPool.GimmeInactiveGameObject();

            if (obj)
            {               
                obj.SetActive(true); // ya no esta disponible en la pool
                obj.transform.position = transform.position;
                obj.GetComponent<Bullet>().SetDirection(transform.forward);
            }
        }
    }
}
