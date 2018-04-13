using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Jobs;

public class VerySimpleJobBehaviour : MonoBehaviour {
	[ComputeJobOptimization]
	struct VerySimpleJob : IJob {
		public int max;

		public long result;

		public void Execute() {
			for (int i = 0; i < max; i++) {
				result += i;
			}
		}
	}

	private JobHandle jobHandle;
	private bool completed;

	void Start() {
		VerySimpleJob job = new VerySimpleJob() {
			max = 65536 * 256 * 127
		};

		jobHandle = job.Schedule();
	}

	void Update() {
		if  (!completed && jobHandle.IsCompleted) {
			Debug.Log(Time.frameCount);

			completed = true;
		}
	}
}
