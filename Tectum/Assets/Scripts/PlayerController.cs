using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float m_Speed = 4.5f;
    public Transform m_RayStart, m_RayEnd;

    private float m_Angle;
    private Rigidbody2D m_rb2d;
    private Vector3 m_Diff;

	void Start ()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        //Rotation
        Vector3 Diff = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        m_Angle = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(m_Angle, Vector3.forward);

        //Movement
        Vector2 Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_rb2d.MovePosition(m_rb2d.position + Movement * Time.deltaTime * m_Speed);

        //RayCasting
        Debug.DrawLine(m_RayStart.position, m_RayEnd.position, Color.green);
    }
}
