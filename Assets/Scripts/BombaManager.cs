using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaManager : MonoBehaviour
{

    [SerializeField] private GameObject bombaFX = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bola"))
        {
            Instantiate(bombaFX, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }

}
