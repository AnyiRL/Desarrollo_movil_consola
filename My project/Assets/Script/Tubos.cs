using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Tubos : MonoBehaviour
{
    public float speed;
    public float maxTime;
    private float currentTime;
    private Vector3 _dir;
    private Rigidbody _rb;
    private float plusSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime)
        {
            currentTime = 0;
            gameObject.SetActive(false); // se "devuelve" a la pool 
        } 
    }
    private void FixedUpdate()
    {
       
        //plusSpeed += Time.deltaTime;
        _rb.velocity = speed * _dir;
        //if ( 20 < plusSpeed)
        //{
        //    plusSpeed = 0;
        //    speed += 1;
        //}      
    }
    //public void SetSpeed(float value)
    //{
    //    speed = value;
    //}
    public void SetDirection(Vector3 value)
    {     
        _dir = value;
    }
}
