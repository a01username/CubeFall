using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Add Variables here
    float jump = 2.0f;
    float speed = 10.0f;
    bool ground = true;
    Rigidbody rb;
    public UnityEvent gameEnd;
    public int heath;
    public int numOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        heath = numOfHearts;
    }
    void Update()
    {
        HeartManager();
        //Add Movement checking here
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && ground)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ground = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ground = false;
        }
    }
    void HeartManager()
    {
        if (heath > numOfHearts)
        {
            heath = numOfHearts;
        }
        for (int i = 0; i < numOfHearts; i++)
        {
            if (i < heath)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    
    void TakeDamage(int damage)
    {
        heath -= damage;
        if (heath == 0)
        {
            hearts[0].sprite = emptyHeart;
            Destroy(this.gameObject);
            gameEnd.Invoke();

        }
    }
    


}
