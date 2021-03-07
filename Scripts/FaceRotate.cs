using UnityEngine;

public class FaceRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(touchDeltaPosition.y, touchDeltaPosition.x) * Mathf.Rad2Deg + 270));

        }
    }
}
