using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [Header("時間設定")]
    [SerializeField, Tooltip("床表示時間")]
    public float stayTime = 3.0f;
    [SerializeField, Tooltip("消えるのにかかる時間")]
    public float fadeDurationTime = 2.0f;
    [SerializeField, Tooltip("消えてる時間")]
    public float hideTime = 3.0f;
    [SerializeField, Tooltip("出現時間")]
    public float AppearanceTime = 2.0f;

    [Header("色設定")]
    public Color BoxColor = Color.white;
    Material floorMaterial;
    private BoxCollider floorCollider;
    void Start()
    {
        floorMaterial = GetComponent<Renderer> ().material;

        floorMaterial.SetColor("_BaseColor", BoxColor);
        floorMaterial.SetFloat("_alpha", 1.0f);

        floorCollider = GetComponent<BoxCollider>(); 

        StartCoroutine(BlinkFloor());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BlinkFloor()
    {
        while (true)
        {

            // 消える
            float elapsed = 0.0f;
            while(elapsed < AppearanceTime)
            {
                elapsed += Time.deltaTime;

                float currentAlpha = Mathf.Lerp(0.0f, 1.0f, elapsed / AppearanceTime);

                floorMaterial.SetFloat("_alpha", currentAlpha);

                yield return null;
            }

            // 表示
            floorCollider.enabled = true;
            floorMaterial.SetFloat("_alpha", 1.0f);
            yield return new WaitForSeconds(stayTime);

            // 消える
            elapsed = 0.0f;
            while(elapsed < fadeDurationTime)
            {
                elapsed += Time.deltaTime;

                float currentAlpha = Mathf.Lerp(1.0f, 0.0f, elapsed / fadeDurationTime);

                floorMaterial.SetFloat("_alpha", currentAlpha);

                yield return null;
            }
            // 消えている
            floorMaterial.SetFloat("_alpha", 0.0f);
            floorCollider.enabled = false;
            yield return new WaitForSeconds(hideTime);
        }
    }
}
