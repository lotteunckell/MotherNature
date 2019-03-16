using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    //earth's stats
    public int humidity;
    public int pollution;
    public int temperature;
    public long age;

    //helpers for stat updating
    private float nextActionIn = 0.0f;
    public float statsUpdateSpeed = 30;

    //helpers for age updating
    private float yearIncreaseIn = 0.0f;
    public float ageUpdateSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        humidity = 50;
        pollution = 50;
        temperature = 50;
        age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateScores();
        updateAge();
    }

    void updateScores()
    {
        if (Time.time > nextActionIn)
        {
            nextActionIn += statsUpdateSpeed;
            humidity += 1;
            pollution -= 1;
            temperature += 1;
            normalizePercent();
        }
    }

    void updateAge()
    {
        if (Time.time > yearIncreaseIn)
        {
            yearIncreaseIn += ageUpdateSpeed;
            age += 1;
        }
    }

    void normalizePercent()
    {
        if (humidity > 100)
        {
            humidity = 100;
        }
        else if (humidity < 0)
        {
            humidity = 0;
        }
        if (pollution > 100)
        {
            pollution = 100;
        }
        else if (pollution < 0)
        {
            pollution = 0;
        }
        if (temperature > 100)
        {
            temperature = 100;
        }
        else if (temperature < 0)
        {
            temperature = 0;
        }
    }
}
