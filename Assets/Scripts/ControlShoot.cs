using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShoot : MonoBehaviour
{
    public float speed = 10f;
    public ShipManager shipManager;
    private SpriteRenderer _spriteRenderer;    

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_spriteRenderer.isVisible)
            //transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<MeteorController>(out var component))
        {
            component.HitByShoot();
        }
        GameManager.Instance.CountHit();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        shipManager.CanFire();
    }
}
