using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerC : MonoBehaviour
{

    public static GameManagerC instance;

    //BOLA
    [SerializeField] private GameObject bola;
    public int bolasNum = 2;
    private bool bolaMorreu = false;
    public int bolasEmCena = 0;
    public Transform pos;

    public int tiro = 0;

    public bool win;

    //public int ondeEstou;
    public bool jogoComecou;

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

        SceneManager.sceneLoaded += Carrega;

        pos = GameObject.Find("PosicaoInicial").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        ScoreManager.instance.GameStartScoreM();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.UpdateScore();
        UiManager.instance.UpdateUI();
        NasceBolas();

        if(bolasNum <= 0)
        {
            GameOver();
        }

        if(win == true)
        {
            //PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex + 1, 1);
            WinGame();
        }
    }

    void NasceBolas()
    {
        if(bolasNum > 0 && bolasEmCena == 0)
        {
            Instantiate(bola, new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
            bolasEmCena += 1;
            tiro = 0;
        }
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if(OndeEstou.instance.fase != 4)
        {
            pos = GameObject.Find("PosicaoInicial").GetComponent<Transform>();
            StartGame();
        }
        
    }

    void GameOver()
    {
        UiManager.instance.GameOverUI();
        jogoComecou = false;
    }

    void WinGame()
    {
        UiManager.instance.WinGameUI();
        jogoComecou = false;
    }

    void StartGame()
    {
        jogoComecou = true;
        bolasNum = 2;
        bolasEmCena = 0;
        win = false;
        UiManager.instance.StartUI();
    }
}
