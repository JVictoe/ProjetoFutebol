using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacao : MonoBehaviour
{

    //Posição da seta
    [SerializeField] private Transform positonStart = default;

    //Seta
    [SerializeField] private Image setaImg = default;

    //Angulo
    public float zRotate;

    // Start is called before the first frame update
    void Start()
    {
        PosicionaSeta();
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoSeta();
        InputDeRotacao();
    }

    void PosicionaSeta()
    {
        setaImg.rectTransform.position = positonStart.position;
    }

    void PosicionaBola()
    {
        this.gameObject.transform.position = positonStart.position;
    }

    void RotacaoSeta()
    {
        setaImg.rectTransform.eulerAngles = new Vector3(0,0, zRotate);
    }

    void InputDeRotacao()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            zRotate += 2.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            zRotate -= 2.5f;
        }
    }
}
