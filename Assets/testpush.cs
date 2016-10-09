using UnityEngine;
using System.Collections;

public class testpush : MonoBehaviour {
    public Transform player;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)){
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1), 1f);
        }


    }
}
