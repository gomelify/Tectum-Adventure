using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float m_Speed = 4.5f;
    public Transform m_RayStart, m_RayEnd;

    private float m_Angle;
    private Rigidbody2D m_rb2d;
    private Vector3 m_Diff;

    //Bullet initialisation
    public GameObject BulletPrefab;

    private List<GameObject> Bullets = new List<GameObject>();
    private float BulletVelocity;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        BulletVelocity = 10;  //Speed of the Projectile

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

        //Bullet
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullets.Add(projectile);

        }
        for (int i = 0; i < Bullets.Count; i++)
        {
            GameObject goBullet = Bullets[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(0, 1) * Time.deltaTime * BulletVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0)
                {
                    DestroyObject(goBullet);
                    Bullets.Remove(goBullet);
                }
            }
        }
    }
}
