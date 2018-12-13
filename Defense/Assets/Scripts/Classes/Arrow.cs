using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the arrow logic and data
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour {

	[SerializeField] private float lifeTime = 5f;

	private float arrowSpeed = 1f;
	private float arrowDamage = 1f;
	private Rigidbody2D rb;

	public float ArrowSpeed { get { return arrowSpeed; } set { arrowSpeed = value; } }
	public float ArrowDamage
	{
		get
		{
			return arrowDamage;
		}
		set
		{
			arrowDamage = value;
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start ()
	{
		StartCoroutine(DestroyAfter(lifeTime));
	}
	
	void FixedUpdate ()
	{
		rb.velocity = transform.up * arrowSpeed;
	}

	IEnumerator DestroyAfter(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
