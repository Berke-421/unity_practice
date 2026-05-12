public Transform sensor3, sensor4;

        // Opens on approach.
        if (Vector3.Distance(transform.position, sensor3.position) < 5f || Vector3.Distance(transform.position, sensor4.position) < 5f)
        {
            isDoorOpen = true; // The door is now open.
        }

        else // The door now closes when far enough away.
            isDoorOpen = false;

        if (isDoorOpen) // The door opens by performing calculations based on world space coordinates.
        {
            if(sensor3.position.z > -4.5f || sensor4.position.z < 3.7f)
            {
                sensor3.position += new Vector3(0, 0, -0.5f) * 2f * Time.deltaTime;
                sensor4.position += new Vector3(0, 0, +0.5f) * 2f * Time.deltaTime;
            }
        }

        else // When the door is closed, calculations are performed based on world coordinates to shut the door.
        {
            if(sensor3.position.z < -1.66f || sensor3.position.z > 1)
            {
                sensor3.position -= new Vector3(0, 0, -0.5f) * 2f * Time.deltaTime;
                sensor4.position -= new Vector3(0, 0, +0.5f) * 2f * Time.deltaTime;
            }
        }
