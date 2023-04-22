using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform limitLeft;
    [SerializeField] Transform limitRight;

    bool isDead;
    [SerializeField] Color deadColor;
    SpriteRenderer spriteRenderer;

    int score = 0;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI gameOverUI;
    [SerializeField] TextMeshProUGUI restartUI;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(0);
                gameOverUI.enabled = false;
                restartUI.enabled = false;
            }
        }else{
            if(Input.GetMouseButtonDown(0)){
                ChangeDirection();
            }
            
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            if(transform.position.x >= limitRight.position.x){
                transform.position = new Vector3(limitRight.position.x, transform.position.y, transform.position.z);
                ChangeDirection();
            }

            if(transform.position.x <= limitLeft.position.x){
                transform.position = new Vector3(limitLeft.position.x, transform.position.y, transform.position.z);
                ChangeDirection();
            }
        }
    }

    void ChangeDirection(){
        speed = -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            isDead = true;
            spriteRenderer.color = deadColor;
            collision.gameObject.GetComponentInParent<Spawner>().stop = true;
            collision.gameObject.SetActive(false);
            gameOverUI.enabled = true;
            restartUI.enabled = true;
        }
        if(collision.CompareTag("Point")){
            if(!isDead){
                score++;
                scoreUI.text = "Score: " + score.ToString();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
