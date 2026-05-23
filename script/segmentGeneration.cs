using UnityEngine;
using System.Collections.Generic;

public class segmentGeneration : MonoBehaviour
{
	public GameObject roadPrefab;   // prefab الطريق
	public Transform player;        // اللاعب
	public int initialRoadCount = 5; // عدد الطرق المبدئي
	public float safeZone = 30f;    // المسافة قبل توليد الطريق الجديد

	private float nextSpawnZ = 0f;
	private Queue<GameObject> activeRoads = new Queue<GameObject>();

	void Start()
	{
		// توليد الطريق المبدئي
		for (int i = 0; i < initialRoadCount; i++)
		{
			SpawnRoad();
		}
	}

	void Update()
	{
		// إذا اقترب اللاعب من نهاية الطريق المولد، نولد قطعة جديدة
		if (player != null && player.position.z + safeZone > nextSpawnZ)
		{
			SpawnRoad();
		}

		// مسح الطرق القديمة لتوفير الذاكرة
		if (activeRoads.Count > initialRoadCount + 2) // ممكن تغير العدد حسب راحتك
		{
			GameObject oldRoad = activeRoads.Dequeue();
			Destroy(oldRoad);
		}
	}

	void SpawnRoad()
	{
		GameObject road = Instantiate(roadPrefab);
		road.transform.position = new Vector3(0f, 0f, nextSpawnZ);

		// تفعيل العوائق بشكل عشوائي لو موجودة
		Transform obstacleContainer = road.transform.Find("Obstacles");
		if (obstacleContainer != null)
		{
			foreach (Transform obstacle in obstacleContainer)
			{
				obstacle.gameObject.SetActive(Random.value > 0.5f);
			}
		}

		// حساب طول الطريق للقطعة القادمة
		float length = 50f; // طول افتراضي
		Transform ground = road.transform.Find("Ground");
		if (ground != null)
		{
			Renderer rend = ground.GetComponent<Renderer>();
			if (rend != null)
				length = rend.bounds.size.z;
		}

		nextSpawnZ += length;
		activeRoads.Enqueue(road);
	}
}
