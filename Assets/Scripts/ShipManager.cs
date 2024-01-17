using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    float shipSpeed = 5.0f;
    //private GameObject space;
    private Vector3 inicial;

    public GameObject shootPrefab;
    public SpriteRenderer laserSpriteRenderer;
    private bool _canFire = true;

    void Start()
    {
        inicial.x = 9f;
        inicial.y = 2.5f;
        //space = GameObject.FindGameObjectWithTag("Space");
        //final = space.transform.position;
    }
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime; ;
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime; ;
            //update the position
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0));

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_canFire)
                {
                    //_canFire = false;
                    GameObject go = Instantiate(shootPrefab);
                    //go.transform.position = this.transform.position;
                    go.transform.position = laserSpriteRenderer.gameObject.transform.position;
                    go.GetComponent<ControlShoot>().shipManager = this;
                    //laserSpriteRenderer.enabled = false;
                }
            }
        }
    }
    public void CanFire()
    {
        _canFire = true;
        laserSpriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Meteor"))
            GameManager.Instance.Crash();
        //else if (collision.CompareTag("Space"))
            //space.transform.position = final;
    }
}
