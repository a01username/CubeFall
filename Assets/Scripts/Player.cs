using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //Add Variables here
    float jump = 1.0f;
    float speed = 10.0f;
    bool ground = true;
    Rigidbody rb;
    public UnityEvent gameEnd;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Add Movement checking here
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && ground)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
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
            Destroy(this.gameObject);
            gameEnd.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ground = false;
        }
    }
    //Add OnCollisionEnter() here


}
