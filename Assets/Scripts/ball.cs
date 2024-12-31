using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float forceVal;
    bool gameStarted;

    private void Awake(){
        rb=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(Input.anyKeyDown){
            StartBounce();
            gameStarted=true;
            GameManager.instance.GameStart();
        }
        }
    }

    void StartBounce(){
        Vector2 bounceDir = new Vector2(Random.Range(-1,1), 1);
        rb.AddForce(bounceDir * forceVal, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="FallCheck"){
            GameManager.instance.Restart();
        }

        if(collision.gameObject.tag=="paddle"){
            GameManager.instance.ScoreUp();
        }
    }
}
