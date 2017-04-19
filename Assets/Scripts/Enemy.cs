using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
{

    //EnemyのHP
    public int _hp = 1;

    //ポイント
    public int _point =1;

    // Use this for initialization
    IEnumerator Start () {

        // アニメーターコンポーネントを取得
        _animator = GetComponent<Animator>();


        // ローカル座標のY軸のマイナス方向に移動する
        Move(transform.up * -1);

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (_canShot == false)
        {
            yield break;
        }

        for (;;)
        {
            //ShotPositionの数
            int count = this.transform.childCount;
            //ShotPositionの数だけ回す
            for (int i = 0; i < count; i++)
            {
                Shot(transform.GetChild(i));
            }
            // shotDelay秒待つ
            yield return new WaitForSeconds(_shotDelay);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(Player)") return;

        // 弾の削除
        Destroy(c.gameObject);

        // PlayerBulletのTransformを取得
        Transform playerBulletTransform = c.transform.parent;

        // Bulletコンポーネントを取得
        Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

        //弾の威力からｈｐを引く
        _hp -= bullet._power;

        if (_hp <= 0)
        {

            // 爆発
            Explosion();

            // エネミーの削除
            Destroy(gameObject);

            FindObjectOfType<Score>().AddPoint(_point);
        }
        else
        {
            _animator.SetTrigger("Damage");
        }
    }

    //**************************************************
    // 処理内容：機体の移動
    // 引数　　：direction 移動方向
    //**************************************************
   protected  override void Move(Vector2 direction)
    {
        //機体の移動
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * _speed;
    }

}
