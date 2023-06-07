using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{
    // Start is called before the first frame update
    //public string SceneName = null;
    // public Vector2 destination;
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         other.transform.position = destination; // 将Player移动到指定位置
    //     }
    // }
    public string SceneName;
    private Vector2 lastPlayerPos;

    // 設定上一個場景的名稱和玩家位置
    public void SetLastScene(string sceneName, Vector2 playerPos)
    {
        SceneName = sceneName;
        lastPlayerPos = playerPos;
    }

    // 載入上一個場景
    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    // 載入新場景
    public void LoadNewScene(string sceneName, Vector2 playerPos)
    {
        // 先設定上一個場景的資訊
        SetLastScene(SceneManager.GetActiveScene().name, playerPos);
        // 載入新場景
        SceneManager.LoadScene(sceneName);
    }

    // 當新場景載入後設定玩家位置
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = lastPlayerPos;
        }
    }

    // 註冊 OnSceneLoaded 事件
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 取消註冊 OnSceneLoaded 事件
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
