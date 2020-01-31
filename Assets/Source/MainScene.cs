using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] PlayableDirector m_playDir;
    [SerializeField] Button m_playBtn;

    private void Start()
    {
        m_playBtn.onClick.AddListener(OnMainClick);
    }

    void OnMainClick()
    {
        StartCoroutine(Co_OnPlayCountDown());
        m_playBtn.enabled = false;
    }

    IEnumerator Co_OnPlayCountDown()
    {
        m_playDir.Play();

        double duration = m_playDir.duration;
        float t_start = Time.time;

        while (Time.time < t_start + duration)
            yield return null;

        SceneManager.LoadScene("game");
    }
}
