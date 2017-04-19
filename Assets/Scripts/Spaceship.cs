using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Spaceship : MonoBehaviour {

    //移動スピード
    public float _speed;
    //弾の発射感覚
    public float _shotDelay;
    //弾のGameObject
    public GameObject _bullet;
    //発射するかのフラグ
    public bool _canShot;
    //爆発のオブジェクト
    public GameObject _explosion;

    // アニメーターコンポーネント
    protected Animator _animator;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //**************************************************
    // 処理内容：爆発のオブジェクト生成
    //**************************************************
    public void Explosion()
    {
        //弾の生成
        Instantiate(_explosion, transform.position, transform.rotation);
    }


    //**************************************************
    // 処理内容：弾の発射
    // 引数　　：Transform 座標
    //**************************************************
    public void Shot(Transform origin)
    {
        //弾の生成
        Instantiate(_bullet, origin.position, origin.rotation);
    }


    //**************************************************
    // 処理内容：機体の移動
    // 引数　　：direction 移動方向
    //**************************************************
    protected abstract void Move(Vector2 direction);
    //{
    //    //機体の移動
    //    this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * _speed;
    //}

}
