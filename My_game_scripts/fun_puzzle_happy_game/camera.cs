using UnityEngine;
public class Camera : MonoBehaviour
{
    /* 
     An algorithm where the camera follows the player's
     position only on the Y and Z axes, without being a child of the player.
     */

    public Transform karakter;
    void Update()
    {
        // copy current camera position (Vector3 is a struct)
        Vector3 pos = transform.position;
        // set camera z relative to the character
        pos.z = karakter.position.z - 6.23f;
        transform.position = pos;

        // NOTE: pos2 is created but not used below
        Vector3 pos2 = transform.position;
        // this line modifies 'pos' (not pos2) — keeps existing behavior but may be a bug
        pos.y = karakter.position.y + 16.92f;
        transform.position = pos;
    }
}
