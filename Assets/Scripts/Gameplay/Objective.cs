using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public abstract class Objective
	{
	    public abstract bool Completed();

		public abstract bool Failed();
	}
}

