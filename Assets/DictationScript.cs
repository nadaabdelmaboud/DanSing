using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class DictationScript : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;

    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;
    public static string allspeech="";
  
    public void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            m_Recognitions.text += text + "\n";
            allspeech += text + " ";
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            m_Hypotheses.text += text;
        };

        //m_DictationRecognizer.DictationComplete += (completionCause) =>
        //{
        //    if (completionCause != DictationCompletionCause.Complete)
        //        Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        //};

        //m_DictationRecognizer.DictationError += (error, hresult) =>
        //{
        //    Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        //};
        m_DictationRecognizer.InitialSilenceTimeoutSeconds=300f;
        m_DictationRecognizer.AutoSilenceTimeoutSeconds = 300f;
        m_DictationRecognizer.Start();
    }
    private void OnDestroy()
    {
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
    }
}