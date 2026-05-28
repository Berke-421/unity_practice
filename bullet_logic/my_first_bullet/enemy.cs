        zaman += Time.fixedDeltaTime; // timeCounter

        if (zaman >= 2f) // if it reaches two
        {
            zaman = 0; // reset the timer
            Instantiate(bullet, transform.position, transform.rotation); // Instantiate the bullet at the enemy's position and rotation
        }
