using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsExemplo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text = default;
    [SerializeField] private TMP_InputField inputText = default;
    [SerializeField] private Button btnSalva = default;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetString("info");
        btnSalva.onClick.AddListener(salvaInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void salvaInfo()
    {
        PlayerPrefs.SetString("info", inputText.text);
        text.text = inputText.text;
    }
}
