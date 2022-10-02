using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Rule
	{
		public string Description { get; protected set; } = "";
	    public abstract bool Broken();
	}
}

