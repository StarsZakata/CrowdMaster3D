using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	bool ApplyyDamage(Rigidbody rigidbody, float force);
}
