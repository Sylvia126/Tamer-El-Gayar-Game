using UnityEngine;

public class Movment : MonoBehaviour
{
	[Header("Forward Movement")]
	public float forwardSpeed = 8f;

	[Header("Lane Settings")]
	public float laneWidth = 4f;
	public float laneChangeSpeed = 15f;

	[Header("Animator")]
	public Animator animator; // اربطي Animator هنا

	[Tooltip("Middle of the road")]
	public Transform middleRoad;

	private float centerX;
	private int currentLane = 1;
	private float targetX;
	private bool isDead = false;

	void Start()
	{
		if (middleRoad != null)
			centerX = middleRoad.position.x;
		else
			centerX = transform.position.x;

		float currentX = transform.position.x;

		if (currentX > centerX + (laneWidth / 2))
			currentLane = 2;
		else if (currentX < centerX - (laneWidth / 2))
			currentLane = 0;
		else
			currentLane = 1;

		targetX = centerX + (currentLane - 1) * laneWidth;
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

		// تأكدي إن Animator مربوط
		if (animator == null)
			animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (isDead)
		{
			animator.SetBool("isRunning", false);
			return;
		}

		// الحركة الأمامية
		transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

		// التغيير بين المسارات
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			ChangeLane(-1);

		if (Input.GetKeyDown(KeyCode.RightArrow))
			ChangeLane(1);

		// تحريك الشخصية على محور X بسلاسة
		Vector3 pos = transform.position;
		float newX = Mathf.Lerp(pos.x, targetX, laneChangeSpeed * Time.deltaTime);
		transform.position = new Vector3(newX, pos.y, pos.z);

		// تشغيل Animation الجري
		float movementMagnitude = Mathf.Abs(targetX - pos.x) + Mathf.Abs(forwardSpeed);
		animator.SetBool("isRunning", movementMagnitude > 0.01f);
	}

	void ChangeLane(int direction)
	{
		if (isDead) return;
		currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
		targetX = centerX + (currentLane - 1) * laneWidth;
	}

	public void StopMoving()
	{
		isDead = true;
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.linearVelocity = Vector3.zero;
			rb.isKinematic = true;
		}

		// إيقاف Animation الجري
		if (animator != null)
			animator.SetBool("isRunning", false);
	}
}
