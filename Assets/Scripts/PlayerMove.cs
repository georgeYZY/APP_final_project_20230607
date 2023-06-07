using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float MoveX;
    private float MoveY;
    public float speed;
    public Joystick joystick;
    private Animator myAnim;
    public DialogBoxScript dialog;

    //bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        GameObject dialogObj = new GameObject("dialog");
        dialog = dialogObj.AddComponent<DialogBoxScript>();
        dialogObj.SetActive(false);
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    public void SetMoveEnabled(bool enabled)
    {
        rb.simulated = enabled;
    }
    void Update()
    {
        if (dialog != null && dialog.isTalking)
        {
            SetMoveEnabled(false);
            joystick.gameObject.SetActive(false);
            return;
        }
        SetMoveEnabled(true);
        joystick.gameObject.SetActive(true);

        if (joystick.isActiveAndEnabled && joystick.gameObject.activeSelf && joystick.enabled) //如果沒有開啟對話框
        {
            MoveX = joystick.Horizontal;
            MoveY = joystick.Vertical;
            rb.velocity = new Vector2(MoveX, MoveY/*speed*Time.deltaTime*/).normalized * speed * Time.deltaTime;

            //Debug.Log(rb.velocity);

            myAnim.SetFloat("moveX", rb.velocity.x);
            myAnim.SetFloat("moveY", rb.velocity.y);

            if (MoveX >= 0.1 || MoveX <= -0.1 || MoveY >= 0.1 || MoveY <= -0.1)
            {
                //Debug.Log("in"); 
                myAnim.SetFloat("lastMoveX", MoveX);
                myAnim.SetFloat("lastMoveY", MoveY);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("ChangeScene"))
        {
            Debug.Log("進入");
            SceneManager.LoadScene(other.gameObject.GetComponent<SceneInfo>().SceneName);
        }
    }
    // void FixedUpdate(){
    //     if(moveX>0 && !facingRiht){
    //         Flip();
    //     }else if(moveX < 0 && facingRiht)
    //     {
    //          Flip();
    //     }
    // }
    // void Flip(){
    //     facingRiht = !facingRiht;
    //     Vector3 theScale = transform.localScale;
    //     theScale.x *= -1;
    //     transform.localScale = theScale;
    // }
}
