using UnityEngine;

namespace MugsOfDogs.Scriptables.Variables
{
	public abstract class Var<T> : ScriptableObject
	{
        public T value;
	}
}
