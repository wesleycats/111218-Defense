using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollision : MonoBehaviour {

	public Base baseClass;

	[SerializeField] private string shooterTag;

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Arrow")
		{
			Projectile projectile = c.GetComponent<Projectile>();
			if (projectile.ShooterTag == shooterTag) return;

			Destroy(c.gameObject);
			baseClass.DecreaseHealth(projectile.Damage);
		}
	}
}
