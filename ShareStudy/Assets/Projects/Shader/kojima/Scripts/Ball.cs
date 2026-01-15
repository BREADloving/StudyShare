using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    private enum Status 
    {
        Idle,
        Hide,
    }

    [Serializable]
    public class BallData
    {
        public int point;
        public float hideTime;
    }

    [SerializeField] private BallData m_data;

    private Material m_material = null;
    private Status m_status = Status.Idle;
    private float m_hideTime = 0;
    private Collider m_collider = null;
    private bool m_isActive = true;

    public Action<BallData> OnTouched { private get; set;  }

    private void Start()
    {
        m_material = GetComponent<Renderer>().material;
        m_collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!m_isActive)
        {
            return;
        }

        switch (m_status)
        {
            case Status.Idle:
                break;
            case Status.Hide:
                m_hideTime += Time.deltaTime;
                if (m_hideTime >= m_data.hideTime)
                {
                    m_hideTime = 0;
                    Visible();
                }
            break;
        }
    }


    private void OnMouseDown()
    {
        if (m_status != Status.Idle)
        {
            return;
        }

        Debug.Log("ƒNƒŠƒbƒN‚³‚ê‚Ü‚µ‚½");
        Hide();

        OnTouched?.Invoke(m_data);
    }

    public void SetActive(bool isActive)
    {
        m_isActive = isActive;


        if (m_isActive)
        {
            Visible();
        }
        else
        {
            Hide();
        }
    }


    public void Visible()
    {
        m_status = Status.Idle;
        m_collider.enabled = true;
        m_material.SetFloat("_alpha", 1.0f);
    }

    public void Hide()
    {
        m_status = Status.Hide;
        m_collider.enabled = false;
        m_material.SetFloat("_alpha", 0.0f);
    }
}
