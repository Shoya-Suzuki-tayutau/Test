using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject _player;

    private GameObject _title;

	// Use this for initialization
	void Start () {
        _title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsPlay() && Input.GetKeyDown(KeyCode.X))
        {
            print(Input.GetKeyDown(KeyCode.X));
            GameStart();
        }
	}

    //**************************************************
    // 処理内容：ゲームスタートさせる
    //**************************************************
    void GameStart()
    {
        _title.SetActive(false);
        Instantiate(_player, _player.transform.position, _player.transform.rotation);
    }

    //**************************************************
    // 処理内容：タイトルに戻す
    //**************************************************
    public void GameOver()
    {
        // ハイスコアの保存
        FindObjectOfType<Score>().Save();
        _title.SetActive(true);
    }


    //**************************************************
    // 処理内容：ゲーム開始しているかどうか
    //**************************************************
    public bool IsPlay()
    {
        return _title.activeSelf == false;
    }
}
