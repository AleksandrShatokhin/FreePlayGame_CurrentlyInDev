using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody rb_fireball;
    private float forceRate = 20.0f;

    void Start()
    {
        rb_fireball = this.GetComponent<Rigidbody>();
        rb_fireball.AddForce(transform.forward * forceRate, ForceMode.Impulse);

        Destroy(this.gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layers.Enemy)
        {
            Destroy(other.GetComponentInParent<Red_Enemy_Controller>().gameObject);
            Destroy(this.gameObject);
        }
    }
}
