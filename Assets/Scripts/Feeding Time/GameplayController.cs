using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MugsOfDogs.Controllers
{
	public class GameplayController : MonoBehaviour
	{
        //Singleton
		public static GameplayController instance;

        //Inspector
		[HideInInspector]
		public FeedingTimeScript currentTreat;

		public GameObject GameOverScreen, ExtraChanceButton;
		public AudioSource DestroySoundEffect;
		public Animator anim;

		//Members
		TreatDropper treatSpawner = null;

		void Awake()
		{
			if (instance == null)
				instance = this;

			treatSpawner = FindObjectOfType<TreatDropper>();
		}

		void Start()
		{
			treatSpawner.SpawnTreat();

			//anim = GetComponent<Animator>();

			m_Raycaster = mainCanvas.GetComponent<GraphicRaycaster>();
			m_EventSystem = mainCanvas.GetComponent<EventSystem>();
		}

		void Update()
		{
			if (ClickedElemenetUI())
				return;

			DetectInput();
		}

		public void DetectInput()
		{
			if (Input.GetMouseButtonDown(0))
			{
				currentTreat.DropTreat();
			}
		}

		public void SpawnNewTreat()
		{
			Invoke("NewTreat", 0.3f);
		}

		void NewTreat()
		{
			treatSpawner.SpawnTreat();
		}

		public void PlaySound()
		{
			DestroySoundEffect.Play();
		}

		public void PlayAnimation()
		{
			anim.SetTrigger("EatingAnimation");
		}

		public void EndGame()
		{
			GameOverScreen.SetActive(true);
			//WalletScript.walletValue += 5;  // Add treats to the wallet here after getting at least 1 star.
			Time.timeScale = 0;

			/*
			// Not yet tested

			if (Score.scoreValue > 15)
			{
				// Save 1 star
				// Add 5 Treats
			}

			if (Score.scoreValue > 20)
			{
				// Save 2 stars
				// Add 7 Treats
			}

			if (Score.scoreValue > 25)
			{
				// Save 3 stars
				// Add 10 Treats
			}
			*/
		}

		// Add Rewared Ad to get a extra chance
		public void ExtraChance()
		{
			GameOverScreen.SetActive(false);
			ExtraChanceButton.SetActive(false); // When you ask for a Extra Chance, this disable the "Extra Chance" button
			Time.timeScale = 1;
		}

		public void RestartGame()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}

		// This code is to avoid dropping the Treat while hiting the pause button (is there anything better?)
		// This should work buy itself, but I had to add a box collider in the screen where you can tap it, that's why it needs a better solution
		public GameObject mainCanvas;
		GraphicRaycaster m_Raycaster;
		PointerEventData m_PointerEventData;
		EventSystem m_EventSystem;

		bool ClickedElemenetUI()
		{
			m_PointerEventData = new PointerEventData(m_EventSystem);
			m_PointerEventData.position = Input.mousePosition;
			m_PointerEventData.position = Input.mousePosition;
			List<RaycastResult> results = new List<RaycastResult>();
			m_Raycaster.Raycast(m_PointerEventData, results);
			return (results.Count > 0);
		}
	}
}