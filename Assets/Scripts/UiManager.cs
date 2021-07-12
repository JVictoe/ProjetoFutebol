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
    [SerializeField] private GameObject losePanel;

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

        SceneManager.sceneLoaded += CarregaPontuacao;
        LigaDesligaPainel(); 
    }

    void CarregaPontuacao(Scene cena, LoadSceneMode modo)
    {
        pontuacaoUI = GameObject.Find("PontosUI").GetComponent<TextMeshProUGUI>();
        bolasUI = GameObject.Find("bolasUI").GetComponent<TextMeshProUGUI>();
        losePanel = GameObject.Find("LosePanel");
    }

    public void UpdateUI()
    {
        pontuacaoUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManagerC.instance.bolasNum.ToString();
    }

    public void GameOverUI()
    {
        losePanel.SetActive(true);
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(Tempo());
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.001f);
        losePanel.SetActive(false);
    }
}
