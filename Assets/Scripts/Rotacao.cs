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

    public bool liberaRot = false;

    public bool liberaChute = false;

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
        LimitaRotacao();
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
        if(liberaRot)
        {
            float moveY = Input.GetAxis("Mouse Y");

            if(zRotate < 90)
            {
                if (moveY > 0)
                {
                    zRotate += 2.5f;
                }
            }            
            
            if(zRotate > 0)
            {
                if (moveY < 0)
                {
                    zRotate -= 2.5f;
                }
            }
        }
    }

    void LimitaRotacao()
    {
        if(zRotate >= 90)
        {
            zRotate = 90;
        }
        
        if(zRotate <= 0)
        {
            zRotate = 0;
        }
    }

    private void OnMouseDown()
    {
        liberaRot = true;
    }

    private void OnMouseUp()
    {
        liberaRot = false;
        liberaChute = true;
    }
}
