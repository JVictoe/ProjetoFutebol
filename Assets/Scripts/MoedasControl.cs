using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedasControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bola"))
        {
            ScoreManager.instance.ColetaMoedas(10);
            AudioManager.instance.SonsFxToca(0);
            Destroy(this.gameObject);
        }
    }
}
