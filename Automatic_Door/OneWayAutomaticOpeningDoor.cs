public Transform sensor1, sensor2; // Double doors that slide in opposite directions.

        // Opens on approach.
        if (Vector3.Distance(sensor1.position, transform.position) < 4f || Vector3.Distance(sensor2.position, transform.position) < 4f)
        {
            isDoorOpen = true; // The door is now open.
        }

        if (isDoorOpen)
        {
            // The door opens by performing calculations based on world space coordinates.
            if (sensor2.transform.position.x < 4f || sensor1.transform.position.x > -3.55f)
            {
                sensor2.position += new Vector3(+0.5f, 0, 0) * 2f * Time.deltaTime;
                sensor1.position += new Vector3(-0.5f, 0, 0) * 2f * Time.deltaTime;
            }
        }
