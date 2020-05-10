using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class micplaykar : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject visualizer;
    public GameObject[] rain;
    static public bool test = false;
    static public bool mic = false;
    int count = 0;
    bool compare = false;
    string lyrics = "Same bed but it feels just a little bit bigger now Our song on the radio but it don't sound the same When our friends talk about you, all it does is just tear me down Cause my heart breaks a little when I hear your name It all just sounds like ooh, ooh ooh hoo hoo Mmm too young too dumb to realize That I should have bought you flowers And held your hand Should have gave you all my hours When I had the chance Take you to every party cause all you wanted to do was dance Now my baby is dancing But she is dancing with another man My pride, my ego, my needs, and my selfish ways Caused a good strong woman like you to walk out my life Now I never  never get to clean up the mess I made oh And it haunts me every time I close my eyes It all just sounds like ooh ooh ooh ooh ooh Mm too young too dumb to realize That I should have bought you flowers And held your hand Should have gave you all my hours When I had the chance Take you to every party cause all you wanted to do was dance Now my baby is dancing But she is dancing with another man Although it hurts I'll be the first to say that I was wrong Oh I know I'm probably much too late To try and apologize for my mistakes But I just want you to know I hope he buys you flowers I hope he holds your hand Give you all his hours When he has the chance Take you to every party Cause I remember how much you loved to dance Do all the things I should have done When I was your man Do all the things I should have done When I was your man";
    string speech;
    string speech2;
    public float result1;
    public float result2;
    public float result;
    public float percentage;
    public GameObject recognition;
    public TextMesh score;
    public GameObject screen;
    public GameObject cubevideo;
    private void Start()
    {

    }

    public void onpick()
    {
        recognition.SetActive(true);
        visualizer.SetActive(true);
        video.Play();
        compare = true;
    }
    public void Result() {
        speech = global::DictationScript.allspeech;
        speech2 = global::IBM.Watsson.Examples.ExampleStreaming.allspeech2;
         result1 = CalculateSimilarity(lyrics, speech);
         result2 = CalculateSimilarity(lyrics, speech2);
        result = (result1 > result2) ? result1 : result2;
        Debug.Log("the compare resultis "+result);
        percentage = result * 100;
        percentage = Mathf.Round(percentage);
        cubevideo.SetActive(false);
        score.text = "Score : "+percentage.ToString()+" %";
        screen.SetActive(true);
        Debug.Log(percentage);
    }
    int ComputeLevenshteinDistance(string source, string target)
    {
        if ((source == null) || (target == null)) return 0;
        if ((source.Length == 0) || (target.Length == 0)) return 0;
        if (source == target) return source.Length;

        int sourceWordCount = source.Length;
        int targetWordCount = target.Length;

        // Step 1
        if (sourceWordCount == 0)
            return targetWordCount;

        if (targetWordCount == 0)
            return sourceWordCount;

        int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

        // Step 2
        for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
        for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

        for (int i = 1; i <= sourceWordCount; i++)
        {
            for (int j = 1; j <= targetWordCount; j++)
            {
                // Step 3
                int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                // Step 4
                distance[i, j] = Mathf.Min(Mathf.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
            }
        }

        return distance[sourceWordCount, targetWordCount];
    }
    float CalculateSimilarity(string source, string target)
    {
        if ((source == null) || (target == null)) return 0.0f;
        if ((source.Length == 0) || (target.Length == 0)) return 0.0f;
        if (source == target) return 1.0f;

        int stepsToSame = ComputeLevenshteinDistance(source, target);
        return (1.0f - ((float)stepsToSame / (float)Mathf.Max(source.Length, target.Length)));
    }

    private void Update()
    {
        if (video.time == 10)
        {
            for (int i = 0; i < rain.Length; i++)
            {
                rain[i].gameObject.SetActive(true);
            }
        }
        if (compare && video.time==210) {
            Result();
            compare = false;
        }
        if (test == true)
        {
            Debug.Log("mic updated");
            count++;
            if (count == 1) { onpick(); }
            test = false;
        }
    }
}
