using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Item : MonoBehaviour
{
    public string dialogContent; // 要顯示的對話內容
    public bool isInteractable = true; // 是否可交互
    public GameObject dialogPanel; // 對話框面板

    private bool isTriggered = false; // 是否已被碰觸過

    void Start()
    {
        // 隱藏對話框面板
        if (dialogPanel != null) {
            dialogPanel.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isInteractable && other.CompareTag("Player") && !isTriggered) {
            isTriggered = true;

            // 顯示對話框面板
            if (dialogPanel != null) {
                dialogPanel.SetActive(true);

                // 更新對話框文字
                Text dialogText = dialogPanel.GetComponentInChildren<Text>();
                if (dialogText != null) {
                    dialogText.text = dialogContent;
                }
            }

            // 刪除自身
            Destroy(gameObject);
        }
    }
}