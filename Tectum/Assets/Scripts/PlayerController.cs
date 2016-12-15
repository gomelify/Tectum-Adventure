using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 4.5f;

    private Rigidbody2D rb2d;
    private Vector3 Diff;
    private float Angle;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        //Rotation
        Vector3 Diff = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        Angle = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

        //Movement
        Vector2 Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.MovePosition(rb2d.position + Movement * Time.deltaTime * Speed);
    }
}
