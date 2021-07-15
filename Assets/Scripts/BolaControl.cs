using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControl : MonoBehaviour
{

    //Seta
    [SerializeField] private GameObject setaGo;

    //Angulo
    public float zRotate;

    public bool liberaRot = false;

    public bool liberaChute = false;

    //FORCA
    [SerializeField] private Rigidbody2D bola = default;
    public float force = 0;
    [SerializeField] private GameObject seta2 = default;

    //PAREDES
    private Transform ParedeRight;
    private Transform ParedeLeft;

    private void Awake()
    {
        setaGo = GameObject.Find("Seta");
        seta2 = setaGo.transform.GetChild(0).gameObject; // Pega o filho de setaGO
        setaGo.GetComponent<Image>().enabled = false;
        seta2.GetComponent<Image>().enabled = false;
        ParedeRight = GameObject.Find("ParedeRight").GetComponent<Transform>();
        ParedeLeft = GameObject.Find("ParedeLeft").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //FORÇA
        bola = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoSeta();
        InputDeRotacao();
        LimitaRotacao();
        PosicionaSeta();

        //FORÇA
        AplicaForca();
        ControlaForca();

        //PAREDES
        Paredes();
    }

    //FORÇA INICIO
    void AplicaForca()
    {

        float x = force * Mathf.Cos(zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(zRotate * Mathf.Deg2Rad);

        if (liberaChute)
        {
            bola.AddForce(new Vector2(x, y));
            liberaChute = false;
        }
    }

    void ControlaForca()
    {
        if (liberaRot)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                seta2.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
                force = seta2.GetComponent<Image>().fillAmount * 1000;
            }

            if (moveX > 0)
            {
                seta2.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
                force = seta2.GetComponent<Image>().fillAmount * 1000;
            }
        }
    }
    //FORÇA FIM

    void PosicionaSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.position = transform.position;
    }

    void RotacaoSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.eulerAngles = new Vector3(0, 0, zRotate);
    }

    void InputDeRotacao()
    {
        if (liberaRot)
        {
            float moveY = Input.GetAxis("Mouse Y");

            if (zRotate < 90)
            {
                if (moveY > 0)
                {
                    zRotate += 2.5f;
                }
            }

            if (zRotate > 0)
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
        if (zRotate >= 90)
        {
            zRotate = 90;
        }

        if (zRotate <= 0)
        {
            zRotate = 0;
        }
    }

    void BolaDinamica()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Paredes()
    {
        if(gameObject.transform.position.x > ParedeRight.position.x)
        {
            Destroy(gameObject);
            GameManagerC.instance.bolasEmCena -= 1;
            GameManagerC.instance.bolasNum -= 1;
        }
        else if(gameObject.transform.position.x < ParedeLeft.position.x)
        {
            Destroy(gameObject);
            GameManagerC.instance.bolasEmCena -= 1;
            GameManagerC.instance.bolasNum -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("morte"))
        {
            Destroy(gameObject);
            GameManagerC.instance.bolasEmCena -= 1;
            GameManagerC.instance.bolasNum -= 1;
        }

        if(collision.gameObject.CompareTag("win"))
        {
            GameManagerC.instance.win = true;
            int temp = OndeEstou.instance.fase + 1;
            PlayerPrefs.SetInt("Level" + temp , 1);
        }
    }

    private void OnMouseDown()
    {
        if(GameManagerC.instance.tiro == 0)
        {
            liberaRot = true;
            setaGo.GetComponent<Image>().enabled = true;
            seta2.GetComponent<Image>().enabled = true;
        }

        
    }

    private void OnMouseUp()
    {
        liberaRot = false;
        setaGo.GetComponent<Image>().enabled = false;
        seta2.GetComponent<Image>().enabled = false;

        if (GameManagerC.instance.tiro == 0 && force > 0)
        {
            liberaChute = true;
            seta2.GetComponent<Image>().fillAmount = 0;
            AudioManager.instance.SonsFxToca(1);
            GameManagerC.instance.tiro = 1;
        }
        
    }

}
