using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public string dialogText;
    public GameObject dialogBox;
    public bool playerNearby;

    private void Start()
    {
        dialogBox.SetActive(false);
        playerNearby = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogBox.SetActive(false);
        }
    }
    
}

