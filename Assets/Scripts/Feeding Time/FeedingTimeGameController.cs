using UnityEngine;
using MugsOfDogs.Inputs;

namespace MugsOfDogs.Controllers
{
	[RequireComponent(typeof(PlayerInput), typeof(TreatDropper))]
	public class FeedingTimeGameControllers : MonoBehaviour
	{
		//Members
		PlayerInput input = null;
		TreatDropper dropper = null;

		void Awake()
		{
			input = GetComponent<PlayerInput>();
			dropper = GetComponent<TreatDropper>();
		}
	}
}