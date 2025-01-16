using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private bool jumpPressed;
    private Rigidbody rb;
    private Animator _animator;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
#if UNITY_EDITOR || UNITY_STANDARLONE //del procesador que se ejecuta antes de compilar   CONDITIONAL COMBINATION

        // PC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
#elif UNITY_ANDROID

        // Android
        foreach (Touch touch in Input.touches) //por cada toque en todos los toques que haya en pantalla
        {
            if (touch.phase == TouchPhase.Began)  //si es el primer toque de la pantalla
            {
                jumpPressed = true;
            }
        }
#endif

    }
    private void FixedUpdate()
    {
        ApplyJumpForce();
    }
    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);  // reiniciar "y" para superar la fuerza de gravedad
            rb.AddForce(Vector3.up * jumpForce);
            jumpPressed = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {

        ResetGame PComponent = collision.gameObject.GetComponent<ResetGame>();

        if (PComponent != null)
        {           
            _animator.Play("muerte_Clip");
    
            if ( currentTime > 2)
            {
                GameManager.instance.Dead(1);
                currentTime = 0;
            }       
        }
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Reset");
        AudioManager.instance.ClearAudios();
    }
    
}
