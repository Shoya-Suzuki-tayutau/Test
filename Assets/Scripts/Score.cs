using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    //scoreのテキスト
    public GUIText _scoreGuiText;
    //hightscoreのテキスト
    public GUIText _hightScoreGuiText;
    //scoreの値
    int _score;
    //hightscoreの値
    int _hightScore;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    // Use this for initialization
    void Start () {
        Initialize();

    }
	
	// Update is called once per frame
	void Update () {
        //ハイスコア更新しているかの判定
        if (_score >= _hightScore)
        {
            _hightScore = _score;
        }

        //表示するScoreの更新
        _scoreGuiText.text = _score.ToString();
        _hightScoreGuiText.text = "HightScore:" + _hightScore.ToString();
    }

    //**************************************************
    // 処理内容：初期化
    //**************************************************
    private void Initialize()
    {
        _score = 0;
        _hightScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    //**************************************************
    // 処理内容：Scoreの加算
    //**************************************************
    public void AddPoint(int point)
    {
        _score += point;
    }

    //**************************************************
    // 処理内容：ハイスコアの保存
    //**************************************************
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, _hightScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }

}
