using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //Playerの移動スピード
    public float _speed = 5.0f;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    // 弾の威力
    public int _power = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //自機を上に移動させる
        this.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * _speed;

        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
    }
}
