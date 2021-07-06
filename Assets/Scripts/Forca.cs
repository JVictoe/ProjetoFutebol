using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forca : MonoBehaviour
{

    [SerializeField] private Rigidbody2D bola = default;
    private float force = 1000f;
    [SerializeField] private Rotacao rot = default;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        AplicaForca();
    }

    void AplicaForca()
    {

        float x = force * Mathf.Cos(rot.zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(rot.zRotate * Mathf.Deg2Rad);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            bola.AddForce(new Vector2(x, y));
        }
    }
}
