using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class BotHealth : Health
	{
	    public override void Die()
		{
			base.Die();
			gameObject.SetActive(false);
		}
	}
}

