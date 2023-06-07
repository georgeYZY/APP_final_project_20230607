using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string targetTag;
    public GameObject dialogBox;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => ShowDialog());
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HideDialog();
        }
    }

    private void ShowDialog()
    {
        GameObject targetObject = GameObject.FindWithTag(targetTag);
        if (targetObject != null)
        {
            ItemScript item = targetObject.GetComponent<ItemScript>();
            if (item.playerNearby)
            {
                dialogBox.SetActive(true);
                Text dialogText = dialogBox.GetComponentInChildren<Text>();
                dialogText.text = item.dialogText;
            }
        }
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }
}
