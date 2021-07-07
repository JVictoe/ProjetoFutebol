using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour
{

    [SerializeField] private GameObject bombaRep = default;

    // Start is called before the first frame update
    void Start()
    {
        bombaRep = GameObject.Find("barril");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Vida());
    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(bombaRep.gameObject);
        Destroy(this.gameObject);
    }

}
