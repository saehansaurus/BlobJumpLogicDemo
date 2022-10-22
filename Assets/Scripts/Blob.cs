using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    private GameObject square;
    public float blobWidth;
    public float jumpPowerScale;
    
    void Start()
    {
        blobWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "square") {
            square = coll.gameObject;
        } else if (coll.gameObject.tag == "circle") {
            Vector3 contactPoint = coll.contacts[0].point;
            Vector3 jumpDirection = ((square.transform.position - contactPoint) + blobWidth * new Vector3(0, 1, 0)).normalized;
            float jumpPower = coll.relativeVelocity.magnitude * jumpPowerScale;

            square.GetComponent<Rigidbody2D>().AddForce(jumpDirection * jumpPower);
        }
    }
}
