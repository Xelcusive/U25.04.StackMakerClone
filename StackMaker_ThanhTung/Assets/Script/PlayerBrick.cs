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

        // Tạo viên gạch và gắn vào BrickHolder
        GameObject newBrick = Instantiate(brickPrefab, brickHolder);
        newBrick.transform.localPosition = new Vector3(0, brickCount * 0.2f, 0); // xếp chồng
    }

    // Đặt gạch xuống đường
    public bool RemoveBrick(Vector3 pos)
    {
        if (brickCount > 0)
        {
            brickCount--;

            // Xóa viên gạch trên lưng
            Transform lastBrick = brickHolder.GetChild(brickHolder.childCount - 1);
            Destroy(lastBrick.gameObject);

            // Đặt viên gạch xuống vị trí đường (pos)
            Instantiate(brickPrefab, pos, Quaternion.identity);

            return true;
        }
        else
        {
            Debug.Log("Hết gạch! Không thể đặt.");
            return false;
        }
    }

    public void ClearBrick()
    {
        brickCount = 0;

        foreach (Transform child in brickHolder)
        {
            Destroy(child.gameObject);
        }
    }
}
