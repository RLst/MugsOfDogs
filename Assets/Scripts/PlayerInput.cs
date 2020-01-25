using UnityEngine;

namespace MugsOfDogs.Inputs
{
	public class PlayerInput : MonoBehaviour
	{
		public Vector2 pos => Input.mousePosition;
		public bool firing => Input.GetMouseButton(0);
		public bool fired => Input.GetMouseButtonDown(0);
		public bool fireUp => Input.GetMouseButtonUp(0);
	}
}