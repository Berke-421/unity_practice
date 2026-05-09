    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dusman"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("odul"))
        {
            isAppleCollected = true;
            score += 1;
            other.gameObject.SetActive(false);
        }
    }
