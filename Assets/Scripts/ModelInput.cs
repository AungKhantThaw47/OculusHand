using System.Collections;
using Oculus.Interaction;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using System.IO;
using TMPro;

public class ModelInput : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public HandVisual LHandJoints;
    private StringBuilder csvContent;
    [System.Serializable]
    public class HandData
    {
        public string data;
        // Add other fields as needed
    }

    void Start()
    {
        textMeshPro.text = "No Sign";
        HandData theData = new HandData();
        theData.data = "[[0.02614065, 0.04852969, 0.08149, 0.1155533, 0.10190149, 0.1160985, 0.0941752, 0.09838805, 0.11096662, 0.08678643, 0.09318216, 0.10614858, 0.08470459, 0.0889438, 0.11663967, 0.13486271]]";

        // Serialize the player data to JSON
        string json = JsonUtility.ToJson(theData);
        UnityEngine.Debug.Log(json);

        // StartCoroutine(RunPythonScript("\""+json+"\""));
        StartCoroutine(RunPythonScript());
    }

    void FixedUpdate()
    {
        
    }

    System.Collections.IEnumerator RunPythonScript()
    {
        while (true)
        {
            csvContent = new StringBuilder();
            for (int i = 0; i < LHandJoints.Joints.Count; i++)
            {
                Transform obj = (Transform)LHandJoints.Joints[i]; // Casting to GameObject
                if (i != 0)
                {
                    csvContent.Append(" " + obj.position.x.ToString() + " " + obj.position.y.ToString() + " " + obj.position.z.ToString());
                }
                else
                {
                    csvContent.Append(obj.position.x.ToString() + " " + obj.position.y.ToString() + " " + obj.position.z.ToString() + " ");
                }
            }
            // Run Python script
            string activateCommand = $"conda activate cpe & python Assets/PythonScripts/dist_calc_input.py " + csvContent.ToString();
            ProcessStartInfo pythonStartInfo = new ProcessStartInfo();
            pythonStartInfo.FileName = "cmd.exe";
            pythonStartInfo.Arguments = $"/C \"{activateCommand}\"";
            pythonStartInfo.UseShellExecute = false;
            pythonStartInfo.RedirectStandardOutput = true;
            pythonStartInfo.RedirectStandardError = true;
            pythonStartInfo.CreateNoWindow = true;

            Process pythonProcess = Process.Start(pythonStartInfo);

            // Read output/error asynchronously
            StreamReader outputReader = pythonProcess.StandardOutput;
            StreamReader errorReader = pythonProcess.StandardError;

            // Wait until process exits
            yield return new WaitUntil(() => pythonProcess.HasExited);

            // Capture output/error
            string output = outputReader.ReadToEnd();
            string error = errorReader.ReadToEnd();

            // Close streams
            outputReader.Close();
            errorReader.Close();

            // Log output/error
            textMeshPro.text = output;
            UnityEngine.Debug.Log("Output: " + output);
            UnityEngine.Debug.Log("Error: " + error);

            yield return new WaitForSeconds(1f);
        }
    }
}
