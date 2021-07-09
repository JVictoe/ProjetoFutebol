using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
    }

    [SerializeField] private GameObject botao;
    [SerializeField] private Transform localBtn;
    public List<Level> levelList;

    void ListaAdd()
    {
        foreach(Level level in levelList)
        {
            GameObject btnNovo = Instantiate(botao);
            BotaoLevel btnNew = btnNovo.GetComponent<BotaoLevel>();
            btnNew.levelTxtBtn.text = level.levelText;
            btnNew.levelTxtBtn.gameObject.SetActive(level.habilitado);

            if (PlayerPrefs.GetInt("Level" + btnNew.levelTxtBtn.text) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
            }

            btnNew.desbloqueadoBtn = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;

            btnNovo.transform.SetParent(localBtn, false);
        }
    }

    void ClickLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    // Start is called before the first frame update
    void Start()
    {
        ListaAdd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
