using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

    public class Villager : MonoBehaviour
    {
        public List<GameObject> tools;

		private void Start()
		{
            ChangeTool();
		}

		public void ChangeTool()
        {
			var index = Random.Range(0, tools.Count);
			SetActiveTool(index);
		}


        private void SetActiveTool(int index)
        {
            for(int i = 0; i < tools.Count; i++)
            {
                tools[i].SetActive(i == index);
			}
        }
    }

}