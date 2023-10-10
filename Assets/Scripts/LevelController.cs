using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
		public bool isGameOver = false;
		public float delay = 0.5f;
		private float m_lastSpawnedTime = 0;

		private void Start()
		{
			m_lastSpawnedTime = Time.time;
		}


		private void Update()
		{
			if (!isGameOver)
			{
				if (Time.time >= m_lastSpawnedTime + delay)
				{
					spawner.Spawn();
					m_lastSpawnedTime = Time.time;
				}
			}
		}
	}

}