using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // tốc độ di chuyển
    private Vector3 moveDir;     // hướng di chuyển

    private Vector2 startPos; // vị trí bắt đầu khi chạm
    private Vector2 endPos;   // vị trí kết thúc khi thả tay

    public enum Direct { None, Forward, Back, Right, Left }
    public Direct direct = Direct.None;

    void Update()
    {
        // Lấy vị trí khi nhấn chuột/touch xuống
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        // Khi thả tay ra -> xác định hướng
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            Vector2 swipe = endPos - startPos;

            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            {
                direct = swipe.x > 0 ? Direct.Right : Direct.Left;
            }
            else
            {
                direct = swipe.y > 0 ? Direct.Forward : Direct.Back;
            }
        }

        // Di chuyển liên tục theo hướng đã chọn
        switch (direct)
        {
            case Direct.Forward: moveDir = Vector3.forward; break;
            case Direct.Back: moveDir = Vector3.back; break;
            case Direct.Right: moveDir = Vector3.right; break;
            case Direct.Left: moveDir = Vector3.left; break;
            default: moveDir = Vector3.zero; break;
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
