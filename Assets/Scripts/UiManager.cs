using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    [SerializeField] private TextMeshProUGUI pontuacaoUI = default;
    [SerializeField] private TextMeshProUGUI bolasUI = default;
    [SerializeField] private GameObject losePanel = default;
    [SerializeField] private GameObject winPanel = default;
    [SerializeField] private GameObject pausePanel = default;

    //PAUSE
    [SerializeField] private Button pauseBtn = default;
    [SerializeField] private Button pauseReturnBtn = default;

    //LOSE
    [SerializeField] private Button JogarNovamenteLoseBtn = default;
    [SerializeField] private Button FasesLoseBtn = default;

    //Win
    [SerializeField] private Button btnLevelWin = default;
    [SerializeField] private Button btnNovamenteWin = default;
    [SerializeField] private Button btnAvancaWin = default;

    public int moedasNumAntes;
    public int moedasNumDepois;
    public int resultado;

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

        SceneManager.sceneLoaded += CarregaPontuacao;

        PegaDados();
    }

    void CarregaPontuacao(Scene cena, LoadSceneMode modo)
    {
        PegaDados();
    }
    //private void Update()
    //{
    //    PegaDados();
    //}

    void PegaDados()
    {
        if (OndeEstou.instance.fase != 4)
        {
            pontuacaoUI = GameObject.Find("PontosUI").GetComponent<TextMeshProUGUI>();
            bolasUI = GameObject.Find("bolasUI").GetComponent<TextMeshProUGUI>();

            losePanel = GameObject.Find("LosePanel");
            winPanel = GameObject.Find("WinPanel");
            pausePanel = GameObject.Find("PausePanel");

            pauseBtn = GameObject.Find("Pause").GetComponent<Button>();
            pauseReturnBtn = GameObject.Find("PauseRetrono").GetComponent<Button>();

            //Lose
            JogarNovamenteLoseBtn = GameObject.Find("JogarNovamenteLose").GetComponent<Button>();
            FasesLoseBtn = GameObject.Find("MenuFasesLose").GetComponent<Button>();

            //Win
            btnLevelWin = GameObject.Find("MenuFasesWin").GetComponent<Button>();
            btnNovamenteWin = GameObject.Find("NovamenteWin").GetComponent<Button>();
            btnAvancaWin = GameObject.Find("AvancarWin").GetComponent<Button>();


            pauseBtn.onClick.AddListener(Pause);
            pauseReturnBtn.onClick.AddListener(Play);

            //Eventos lose
            JogarNovamenteLoseBtn.onClick.AddListener(JogarNovamente);
            FasesLoseBtn.onClick.AddListener(Fases);

            //Eventos win
            btnLevelWin.onClick.AddListener(Fases);
            btnNovamenteWin.onClick.AddListener(JogarNovamente);
            btnAvancaWin.onClick.AddListener(ProximaFase);

            moedasNumAntes = PlayerPrefs.GetInt("moedasSave");
        }
    }

    public void StartUI()
    {
        LigaDesligaPainel();
    }

    public void UpdateUI()
    {
        pontuacaoUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManagerC.instance.bolasNum.ToString();
        moedasNumDepois = ScoreManager.instance.moedas;
    }

    public void GameOverUI()
    {
        losePanel.SetActive(true);
    }

    public void WinGameUI()
    {
        winPanel.SetActive(true);
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(Tempo());
    }

    void Pause()
    {
        pausePanel.SetActive(true);
        pausePanel.GetComponent<Animator>().Play("MoveUi_Pause");
        Time.timeScale = 0;
    }

    void Play()
    {
        pausePanel.GetComponent<Animator>().Play("MoveUi_Retorno");
        Time.timeScale = 1;
        StartCoroutine(EsperaPause());
    }

    IEnumerator EsperaPause()
    {
        yield return new WaitForSeconds(0.8f);
        pausePanel.SetActive(false);
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.001f);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    void JogarNovamente()
    {
        if(!GameManagerC.instance.win)
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
        }
        else
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = 0;
        }
   
    }

    void Fases()
    {
        if(!GameManagerC.instance.win)
        {
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
            SceneManager.LoadScene(4);
        }
        else
        {
            resultado = 0;
            SceneManager.LoadScene(4);
        }  
    }

    void ProximaFase()
    {
        if(GameManagerC.instance.win)
        {
            int temp = OndeEstou.instance.fase + 1;

            SceneManager.LoadScene(temp);
        }
    }

}
