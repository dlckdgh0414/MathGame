using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProblemJsonLoad : MonoBehaviour
{
    public QuestionList questionList;

    string sourcePath;
    string targetPath;

    void Start()
    {
        sourcePath = Application.persistentDataPath + "/questions.json";
        targetPath = Application.dataPath + "/questions.json";
        Debug.Log("StreamingAssets Path: " + Application.streamingAssetsPath);
        // 게임 실행 파일이 있는 경로에 JSON 파일 저장
        // 파일이 있으면 내용을 불러옴
        Debug.Log("JSON 파일 저장 경로: " + targetPath); Debug.Log("Source Path: " + sourcePath);
        Debug.Log("Target Path: " + targetPath);
        LoadJSONFile();

    }

    void LoadJSONFile()
    {
        if (File.Exists(targetPath))
        {
            // 파일에서 JSON 데이터를 읽어옴
            string jsonData = File.ReadAllText(targetPath);
            questionList = JsonUtility.FromJson<QuestionList>(jsonData);

            // 첫 번째 문제 출력
            Debug.Log("첫 번째 문제: " + questionList.questions[0].question);
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다.");
        }
    }
}
