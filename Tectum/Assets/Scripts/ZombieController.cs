using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public GameObject m_Player;
    public float m_Speed;

    private Vector3 m_Diff;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        //Moving towards Player
        m_Diff = m_Player.transform.position - transform.position;
        m_Diff.Normalize();

        transform.position = transform.position + (m_Diff * m_Speed);

    }
}
