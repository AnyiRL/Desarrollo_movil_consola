using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { POINTS, LIFES };
    public int initialPoints;
    public int initialLifes;
    private int points = 0;
    private int lifes = 3;
    private int dead = 0;

    private void Awake()
    {

        //Singleton         //singleton accesible para cualquiera, solo existe una instancia  
        if (!instance)     // si instance no tiene informacion
        {
            instance = this;    // instance se asigna a este objet.                                 el gameManager querra crearse, si no hay otro antes este sera el principal
            DontDestroyOnLoad(gameObject);        //no se destruye con la carga de escenas 
        }
        else
        {
            Destroy(gameObject);    //se destruye el  gameObject para que no  haya dos o mas gm en el juego
        }
    }
    void Start()
    {
        initialPoints = points;
        initialLifes = lifes;
    }
    private void Update()
    {

    }
    public int GetPoints()
    {
        return points;
    }
    public void AddPoints(int pointA)
    {
        points += pointA;
    }
    public int GetLifes()
    {
        return lifes;
    }
    public void AddLifes(int lifeA)
    {
        lifes += lifeA;
    }
    public int GetDead()
    {
        return dead;
    }
    public void Dead(int deadA)
    {
        dead += deadA;

        if (dead > 2)
        {
            AdDisplayManager.instance.ShowAd();
            dead = 0;
        }
    }

    public void QuitLifes(int valor)
    {
        lifes -= valor;

        if (lifes <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Reset()
    {
        points = initialPoints; 
        lifes = initialLifes;
    }
    
    public void Exit()
    {
        Application.Quit();// cierra la aplicacion
    }
}

