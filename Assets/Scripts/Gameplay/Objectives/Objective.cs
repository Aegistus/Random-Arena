using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Objective
	{
		public string Description { get; protected set; } = "";
		public abstract void Setup();
	    public abstract bool Completed();
	}
}

