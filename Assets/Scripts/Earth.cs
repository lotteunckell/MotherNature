using UnityEngine;
using System;

public class Earth : MonoBehaviour
{

    private bool running;
    private float startTime;
    private float timeSpendInMenu;
    private float elapsedTime;

    //earth's stats
    public int humidity;
    public int pollution;
    public int temperature;
    public long age;

    //helpers for stat updating
    private float nextActionInHumidity = 0.0f;
    private float nextActionInTemperature = 0.0f;
    private float nextActionInPollution = 0.0f;
    public float pollutionUpdateSpeed = 30; //speed in sek

    //helpers for age updating
    private float yearIncreaseIn = 0.0f;
    public float ageUpdateSpeed = 1; //speed in sek

    //helpers for humidity and temperature updating
    private GameObject sun;
    public int statChangeSpeed = 30; //speed in sek
    public int distanceChangedBy;

    // Start is called before the first frame update
    private void Start()
    {
        startTime = Time.time;
        running = false;
        humidity = 50;
        pollution = 0;
        temperature = 50;
        age = 0;
        sun = GameObject.Find("Sun");
        distanceChangedBy = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!running) timeSpendInMenu = Time.time - startTime;
        if (running) 
        {
            elapsedTime = Time.time - timeSpendInMenu;
            updateAge();
            updateHumidity();
            updateTemperature();
            updatePollution();
            normalizePercent();
        }
    }

    private void updateAge()
    {
        if (elapsedTime > yearIncreaseIn)
        {
            yearIncreaseIn += ageUpdateSpeed;
            age += 1;
        }
    }

    private void updateHumidity()
    {
        if (elapsedTime > nextActionInHumidity)
        {
            //wann die humidity sinkt hängt von dem Abstand zur Sonne ab
            nextActionInHumidity += statChangeSpeed - distanceChangedBy;
            humidity -= 1;
        }
    }

    private void updateTemperature()
    {
        if (elapsedTime > nextActionInTemperature)
        {
            //wann die temperature steigt hängt von dem Abstand zur Sonne ab
            nextActionInTemperature += statChangeSpeed - distanceChangedBy;
            temperature += 1;
        }
    }

    private void updatePollution()
    {
        if (elapsedTime > nextActionInPollution)
        {
            if (pollution <= 40)
            {
                nextActionInPollution += pollutionUpdateSpeed * 2;
            }
            else if (pollution <= 80)
            {
                nextActionInPollution += pollutionUpdateSpeed;
            }
            else
            {
                nextActionInPollution += pollutionUpdateSpeed / 2;
            }
            pollution += 1;
        }
    }

    private void normalizePercent()
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

    public void runningNow()
    {
        running = true;
    }
}
