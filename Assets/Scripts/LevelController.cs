using System;
using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
		private float m_lastSpawnedTime = 0;

		public float delayMax = 2f;
		public float delayMin = 0.5f;
		public float delayStep = 0.1f;

		public int score = 0;
		public int hightScore = 0;

		private float m_delay = 0.5f;

		private void Awake()
		{	
		}

		private void Start()
		{
			m_lastSpawnedTime = Time.time;
			RefreshDelay();

			StartCoroutine(WaitEvent(OnFinishWaitEvent));
		}

		private void OnFinishWaitEvent()
		{
			Debug.Log("");
		}

		private void OnEnable()
		{	
			GameEvents.onCollisionStones += GameOver;
			GameEvents.onStickHit += OnStickHit;
		}

		private void OnDisable()
		{
			GameEvents.onCollisionStones -= GameOver;
			GameEvents.onStickHit -= OnStickHit;
		}

		private void OnStickHit()
		{
			score++;
			hightScore = Mathf.Max(hightScore, score);

			Debug.Log($"score: {score} - hightScore: {hightScore}");
		}

		private void GameOver()
		{
			Debug.Log("!!! GAME OVER !!!");
			enabled = false;
		}

		private void Update()
		{
			if (Time.time >= m_lastSpawnedTime + m_delay)
			{
				spawner.Spawn();
				m_lastSpawnedTime = Time.time;

				RefreshDelay();
			}
		}

		public void RefreshDelay()
		{
			m_delay = UnityEngine.Random.Range(delayMin, delayMax);
			delayMax = Mathf.Max(delayMin, delayMax - delayStep);
		}


		IEnumerator WaitEvent(System.Action callBack)
		{
			yield return new WaitForSeconds(delayStep);
			callBack?.Invoke();
		}
	}
}