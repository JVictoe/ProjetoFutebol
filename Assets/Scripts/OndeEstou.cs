using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OndeEstou : MonoBehaviour
{

    public int fase;

    public static OndeEstou instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void VerificaFase(Scene cena, LoadSceneMode mode)
    {
        fase = SceneManager.GetActiveScene().buildIndex;
    }

}
