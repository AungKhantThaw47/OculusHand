using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
using System.IO;
using System.Text;

public class CSVOutput : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float countdownDuration = 5f;
    public int countdownNumber = 10;

    public HandVisual LHandJoints;

    private float countdownTimer;
    private bool countdownStarted = false;
    private bool continueCollection = true;
    private StringBuilder csvContent = new StringBuilder();
    private string[] data = new string[]
        {
            "Name, Age, Country",
            "John, 25, USA",
            "Alice, 30, UK",
            "Bob, 22, Canada"
        };

    // Start is called before the first frame update
    void Start()
    {
        //WriteCSV();
        Debug.Log(LHandJoints.Joints);
        textMeshPro.text = "Test Count Down";
        for (int i = 0; i < LHandJoints.Joints.Count; i++)
        {
            Transform obj = (Transform)LHandJoints.Joints[i]; // Casting to GameObject
            if (i != 0)
            {
                csvContent.Append(", " + obj.name + "_Position_X, " + obj.name + "_Position_Y, " + obj.name + "_Position_Z, " + obj.name + "_Rotation_X, " + obj.name + "_Rotation_Y, " + obj.name + "_Rotation_Z");
            }
            else
            {
                csvContent.Append(obj.name + "_Position_X, " + obj.name + "_Position_Y, " + obj.name + "_Position_Z, " + obj.name + "_Rotation_X, " + obj.name + "_Rotation_Y, " + obj.name + "_Rotation_Z");
            }
            Debug.Log("Object " + i + ": " + obj.name);
        }
        csvContent.AppendLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownStarted)
        {
            // Update the countdown timer
            countdownTimer -= Time.deltaTime;
            textMeshPro.text = countdownTimer.ToString();
            // Check if the countdown has finished
            if (countdownTimer <= 0f)
            {
                // Stop the countdown
                countdownStarted = false;

                // Call the function after 5 seconds (in this example, we call ExampleFunction)
                Invoke("CollectData", 5f);
            }
        }
    }

    public void InitiateCountDown()
    {
        // Set the countdown timer to the specified duration
        countdownTimer = countdownDuration;

        // Set the countdown started flag to true
        countdownStarted = true;
    }

    void CollectData()
    {
        Debug.Log("Start Collect Data");
        StartCoroutine(CollectingData());
    }

    IEnumerator CollectingData()
    {
        while (countdownNumber > 0)
        {
            // Code to be executed every second
            Debug.Log("Executing every second...");
            Debug.Log(countdownNumber.ToString());
            Debug.Log("Collect Data");
            //for (int i = 0; i < LHandJoints.Joints.Count; i++)
            //{
            //    Transform obj = (Transform)LHandJoints.Joints[i]; // Casting to GameObject
            //    Debug.Log("Object " + i + ": " + obj.name);
            //}

            for (int i = 0; i < LHandJoints.Joints.Count; i++)
            {
                Transform obj = (Transform)LHandJoints.Joints[i]; // Casting to GameObject
                if (i != 0)
                {
                    csvContent.Append(", " + obj.position.x.ToString() + ", " + obj.position.y.ToString() + ", " + obj.position.z.ToString() + ", " + obj.rotation.x.ToString() + ", " + obj.rotation.y.ToString() + ", " + obj.rotation.z.ToString());
                }
                else
                {
                    csvContent.Append(obj.position.x.ToString() + ", " + obj.position.y.ToString() + ", " + obj.position.z.ToString() + ", " + obj.rotation.x.ToString() + ", " + obj.rotation.y.ToString() + ", " + obj.rotation.z.ToString());
                }
                // Debug.Log("Object " + i + ": " + obj.name);
            }
            csvContent.AppendLine();
            textMeshPro.text = countdownNumber.ToString();
            countdownNumber = countdownNumber - 1;
            // countdownNumber = countdownNumber ;
            // Wait for 1 second
            yield return new WaitForSeconds(0.2f);
        }
        WriteCSV();
    }

    void WriteCSV()
    {
        string filePath = Application.dataPath + "/data.csv"; // Path to the CSV file

        File.WriteAllText(filePath, csvContent.ToString());
        textMeshPro.text = "File Written";
        // Data to write to the CSV file


        // Write data to the CSV file
        //using (StreamWriter writer = new StreamWriter(filePath))
        //{
        //    foreach (string line in data)
        //    {
        //        writer.WriteLine(line);
        //    }
        //}

        Debug.Log("CSV file written successfully!");
    }
}
