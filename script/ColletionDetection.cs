using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
	private AudioSource backgroundMusic;
	private AudioSource collisionSound;
	private Animator animator;
	private bool isDead = false;

	// ãÏÉ ÇáÇäÊÙÇÑ ÈÚÏ ÇáÇäíãíÔä ŞÈá ÅÚÇÏÉ ÊÍãíá ÇáãÔåÏ
	public float reloadDelay = 2f;

	void Start()
	{
		// ÕæÊ ÇáÇÕØÏÇã ãä ÇáÍÇÌÒ
		collisionSound = GetComponent<AudioSource>();
		if (collisionSound == null)
			Debug.LogWarning("AudioSource Úáì åĞÇ GameObject ÛíÑ ãæÌæÏ!");

		// Animator ãä ÇááÇÚÈ
		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		if (playerObj != null)
		{
			animator = playerObj.GetComponent<Animator>();
			if (animator == null)
				Debug.LogWarning("Animator ÛíÑ ãæÌæÏ Úáì Player!");
		}
		else
		{
			Debug.LogWarning("Player ãÔ ãæÌæÏ Ãæ Tag ÛíÑ ÕÍíÍ!");
		}

		// ãæÓíŞì ÇáÎáİíÉ
		GameObject musicObj = GameObject.Find("BackgroundMusic");
		if (musicObj != null)
		{
			backgroundMusic = musicObj.GetComponent<AudioSource>();
			if (backgroundMusic == null)
				Debug.LogWarning("AudioSource ÛíÑ ãæÌæÏ Úáì BackgroundMusic!");
		}
		else
		{
			Debug.LogWarning("BackgroundMusic GameObject ãÔ ãæÌæÏ!");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !isDead)
		{
			isDead = true;
			StartCoroutine(HitAndStop(other.gameObject));
		}
	}

	IEnumerator HitAndStop(GameObject player)
	{
		// æŞİ ãæÓíŞì ÇáÎáİíÉ
		if (backgroundMusic != null)
		{
			backgroundMusic.Stop();
			backgroundMusic.volume = 0;
		}

		// ÊÔÛíá ÕæÊ ÇáÇÕØÏÇã İæÑ ÇáÇÕØÏÇã
		if (collisionSound != null)
			collisionSound.Play();

		// ÊÔÛíá ÃäíãíÔä ÇáæŞÚÉ İæÑ ÇáÇÕØÏÇã
		if (animator != null)
			animator.SetTrigger("Fall");

		// æŞİ ÍÑßÉ ÇááÇÚÈ İæÑ ÇáÇÕØÏÇã
		Rigidbody rb = player.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.linearVelocity = Vector3.zero;
			rb.isKinematic = true;
		}

		// ÇáÇäÊÙÇÑ ŞÈá ÅÚÇÏÉ ÊÍãíá ÇáãÔåÏ
		yield return new WaitForSeconds(reloadDelay);

		SceneManager.LoadScene(0);
	}
}
