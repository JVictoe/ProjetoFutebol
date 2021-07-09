using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            GameObject newBtn = Instantiate(botao) as GameObject;
            BotaoLevel btnNew = newBtn.GetComponent<BotaoLevel>();
            btnNew.levelTxtBtn.text = level.levelText;
            btnNew.desbloqueadoBtn = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;
            btnNew.levelTxtBtn.gameObject.SetActive(level.habilitado);

            newBtn.transform.SetParent(localBtn, false);
        }
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
