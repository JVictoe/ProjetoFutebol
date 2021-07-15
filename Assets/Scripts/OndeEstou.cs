using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OndeEstou : MonoBehaviour
{

    public int fase;

    [SerializeField] private GameObject UiManagerGO = default;
    [SerializeField] private GameObject GameManagerGO = default;

    public static OndeEstou instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += VerificaFase;
    }

    void VerificaFase(Scene cena, LoadSceneMode mode)
    {
        fase = SceneManager.GetActiveScene().buildIndex;

        if(fase != 4)
        {
            Instantiate(UiManagerGO);
            Instantiate(GameManagerGO);
        }
    }

}
