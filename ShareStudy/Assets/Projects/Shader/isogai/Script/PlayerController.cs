using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    bool bTransparentMode = false;
    public int Score { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_Alpha", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (bTransparentMode)
        {
            GetComponent<Renderer>().material.SetFloat("_Alpha", 0.2f);
        }
        else
        {
            GetComponent<Renderer>().material.SetFloat("_Alpha", 1.0f);
            Score += 1;
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("ƒNƒŠƒbƒN");
        bTransparentMode = !bTransparentMode;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!bTransparentMode)
        {
            Time.timeScale = 0;
        }
    }
}
