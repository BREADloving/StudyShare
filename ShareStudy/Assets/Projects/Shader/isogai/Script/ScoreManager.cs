using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObj = null;
    [SerializeField] private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TMPro.TextMeshProUGUI text = scoreObj.GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Score:" + playerController.Score;
    }
}
