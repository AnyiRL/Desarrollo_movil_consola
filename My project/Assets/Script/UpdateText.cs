using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;

    private TMP_Text textComponent;
    private int points;
    private int lifes;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "POINTS : " + GameManager.instance.GetPoints();
        
    }
}
