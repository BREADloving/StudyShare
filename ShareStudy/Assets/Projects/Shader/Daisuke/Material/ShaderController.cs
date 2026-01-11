using UnityEngine;
using System.Collections;

public class ShaderController : MonoBehaviour{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        GetComponent<Renderer> ().material.SetColor ("_BaseColor", Color.black);
    }
}
