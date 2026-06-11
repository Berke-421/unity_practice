using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
     0°   -> sunrise
    90°  -> daytime
    180° -> sunset
    270° -> midnight
    360° -> new day
     */

    public float speed, xRot; // time progression speed and sun angle

    public bool morning; // whether it's morning (true if morning, false if night)
    void Start()
    {
        speed = 3f;
        morning = true;
        xRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        xRot += speed * Time.deltaTime; // time passes, increase angle

        if (xRot >= 360f) // if a full rotation completed
            xRot = 0; // reset angle

        transform.rotation = Quaternion.Euler(xRot, 0f, 0f); // advance rotation

        if (xRot < 180f) // if it's morning (first half of day)
        {
            morning = true; // set morning flag
        }
        else // if it's not morning
        {
            morning = false; // clear morning flag
        }
    }
}
