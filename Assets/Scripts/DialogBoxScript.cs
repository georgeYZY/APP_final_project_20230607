using UnityEngine;

public class DialogBoxScript : MonoBehaviour
{
    public bool isAutoProgress = false;
    public bool isTalking = false;

    private void Update()
    {
        if (isAutoProgress && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)))
        {
            gameObject.SetActive(false);
            //GameObject.Find("Player").GetComponent<PlayerMove>().isTalking = false; //角色移動繼續
        }
    }
    public void SetTalking(bool talking)
    {
        isTalking = talking;
    }
}
