using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform startPoint;   // Vị trí bắt đầu
    public Transform finishBox;    // Đích
    public GameObject brickPrefab; // Prefab gạch
    public Transform brickParent;  // Nơi chứa các gạch

    public void InitLevel()
    {
        Debug.Log("Initialize Level...");

        // Đặt Player về vị trí StartPoint
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = startPoint.position;

        // Xóa toàn bộ gạch cũ
        foreach (Transform child in brickParent)
        {
            Destroy(child.gameObject);
        }

        // Tạo lại gạch (ví dụ 10 viên)
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(i, 0, 2);
            Instantiate(brickPrefab, pos, Quaternion.identity, brickParent);
        }
    }
}
