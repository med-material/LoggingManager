using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousLogging : MonoBehaviour
{
    [SerializeField] float samplingFrequency = 0.02f; // 0.02f = every 20ms
    [SerializeField] public DataProvider[] dataProviders; // Array of data providers to gather data from

    [SerializeField] private LoggingManager loggingManager;

    private bool isLoggingStarted = false;

    void Start()
    {
        loggingManager.Log("Meta", "SamplingFrequency", samplingFrequency);
        StartLogging();
    }

    public void StartLogging()
    {
        if (isLoggingStarted) return; // If the sample logger is already started, return. To avoid some useless GC alloc.

        StartCoroutine("SampleLog", samplingFrequency);
        isLoggingStarted = true;
    }

    public void FinishLogging()
    {
        StopCoroutine("SampleLog");
        isLoggingStarted = false;
    }

    // Generates a "logs" row (see class description) from the given datas. Adds mandatory parameters and
    // the PersistentEvents parameters to the row when generating it.
    private IEnumerator SampleLog(float sampleFreq)
    {
        while (true)
        {
            Dictionary<string, object> sampleLog = new Dictionary<string, object>() {
                {"Event", "Sample"},
            };

            // Adds the parameters from all DataProvider components
            foreach (DataProvider provider in dataProviders)
            {
                if (provider != null)
                {
                    Dictionary<string, object> providerLogs = provider.GetData();
                    foreach (KeyValuePair<string, object> pair in providerLogs)
                    {
                        sampleLog[pair.Key] = pair.Value;
                    }
                }
            }

            loggingManager.Log("Sample", sampleLog);
            yield return new WaitForSeconds(sampleFreq);
        }
    }
}
