using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    public GameObject SwordPrefab;
    public GameObject SwordContainer;
    // public GameObject TextField;

    private float prev_position_x = 0f;
    private bool face_right = true;

    void Awake() {
        Transform initial_transform = SwordContainer.transform;
        GameObject Sword = Instantiate(SwordPrefab, initial_transform);
        Sword.transform.SetParent(SwordContainer.transform);
    }

    void FixedUpdate() {
        // float delta = transform.position.x - prev_position_x;
        // //Debug.Log("delta");
        // //Debug.Log(delta);
        // if ((delta > 0f && !face_right) || (delta < 0f && face_right)) {
        //     flip();
        // }
        // prev_position_x = transform.position.x;
    }

//     void flip() {
//         face_right = !face_right;
//         transform.Rotate(0f, 180f, 0f);
//         TextField.transform.Rotate(0f, 180f, 0f);
//     }
}
