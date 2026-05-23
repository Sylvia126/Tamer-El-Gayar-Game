using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;        // ÇÓÍÈ ÇááÇÚÈ åäÇ
	public Vector3 offset = new Vector3(0, 5, -10); // ÇáãÓÇİÉ Èíä ÇáßÇãíÑÇ æÇááÇÚÈ
	public float smoothSpeed = 0.125f;             // ÓÑÚÉ ÇáÊäÚíã (ÇÎÊíÇÑí)

	void LateUpdate()
	{
		if (target == null) return;

		// 1. ÍÓÇÈ ÇáãæŞÚ ÇáãØáæÈ ááßÇãíÑÇ
		// ãáÇÍÙÉ: áæ ÚÇíÒ ÇáßÇãíÑÇ ãÊÊÍÑßÔ íãíä æÔãÇá ãÚ ÇááÇÚÈ æÊİÖá İí ÇáäÕ
		// Îáí ŞíãÉ ÇáÜ X ËÇÈÊÉ (ãËáÇğ 1050.14)
		Vector3 desiredPosition = target.position + offset;

		// 2. ÇáÍÑßÉ ÇáÓáÓÉ äÍæ ÇáãæŞÚ ÇáÌÏíÏ
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		// 3. ÊØÈíŞ ÇáÍÑßÉ
		transform.position = smoothedPosition;

		// 4. ÌÚá ÇáßÇãíÑÇ ÊäÙÑ ÏÇÆãÇğ Åáì ÇááÇÚÈ (ÇÎÊíÇÑí)
		// transform.LookAt(target); 
	}
}