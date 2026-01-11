using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI m_scoreUI;
    [SerializeField] private TMPro.TextMeshProUGUI m_timerUI;
    [SerializeField] private GameObject m_normalBallRoot;
    [SerializeField] private GameObject m_bigBallRoot;

    private float m_score = 0;
    private float m_time = 15;
    private bool m_isGameEnd = false;
    private List<Ball> m_balls = new List<Ball>();

    void Start()
    {
        foreach (var child in m_normalBallRoot.GetComponentsInChildren<Ball>())
        {
            InitializeBall(child);
        }

        foreach (var child in m_bigBallRoot.GetComponentsInChildren<Ball>())
        {
            InitializeBall(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_time -= Time.deltaTime;
        m_time = Mathf.Max(m_time, 0);

        // タイマーが0になった時
        if (!m_isGameEnd && m_time <= 0)
        {
            m_isGameEnd = true;
            foreach (var ball in m_balls)
            {
                ball.SetActive(false);
            }
        }

        m_scoreUI.text = $"Score: {m_score}";
        m_timerUI.text = $"Timer: {string.Format("{0:0.0}", m_time)} sec";
    }

    private void InitializeBall(Ball ball)
    {
        // クリックしたとき
        ball.OnTouched = (data) => 
        {
            if (m_isGameEnd)
            {
                return;
            }
            m_score += data.point;
        };

        m_balls.Add(ball);
    }
}
