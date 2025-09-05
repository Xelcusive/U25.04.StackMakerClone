using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrick : MonoBehaviour
{
    public int brickCount = 0;
    public Transform brickHolder;     // nơi chứa gạch
    public GameObject brickPrefab;    // prefab gạch để cõng

    // Thêm gạch vào người
    public void AddBrick()
    {
        brickCount++;

        // Tạo viên gạch và gắn vào BrickHolder (cõng trên lưng)
        GameObject newBrick = Instantiate(brickPrefab, brickHolder);
        newBrick.transform.localPosition = new Vector3(0, brickCount * 0.2f, 0); // xếp chồng
    }

    // Đặt gạch xuống đường
    public bool RemoveBrick(Vector3 pos, Transform blockTransform = null)
    {
        if (brickCount > 0)
        {
            brickCount--;

            // Xóa viên gạch trên lưng
            Transform lastBrick = brickHolder.GetChild(brickHolder.childCount - 1);
            Destroy(lastBrick.gameObject);

            // Spawn gạch prefab nhô lên block trắng
            if (blockTransform == null)
            {
                Instantiate(brickPrefab, pos + Vector3.up * 0.1f, Quaternion.identity);
            }
            // Đổi block trắng thành block gạch
            else
            {
                MeshRenderer rend = blockTransform.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.red; // đổi màu block trắng thành đỏ
                }
            }

            return true;
        }
        else
        {
            Debug.Log("Hết gạch! Không thể đặt.");

            return false;
        }
    }

    // Xóa hết gạch khi reset
    public void ClearBrick()
    {
        brickCount = 0;

        foreach (Transform child in brickHolder)
        {
            Destroy(child.gameObject);
        }
    }
}
