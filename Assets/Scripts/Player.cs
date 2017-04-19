using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spaceship
{

	// Use this for initialization
	void Start () {
       StartCoroutine("Shoot");
	}
	
	// Update is called once per frame
	void Update () {

        //横の操作
        float x = Input.GetAxisRaw("Horizontal");
        //縦の操作
        float y = Input.GetAxisRaw("Vertical");

        //縦と横の値をノーマライズ
        Vector2 direction = new Vector2(x, y).normalized;

        //移動
        Move(direction);

    }

    IEnumerator Shoot()
    {
        for(;;)
        {
            Shot(this.gameObject.transform);

            // ショット音を鳴らす
            GetComponent<AudioSource>().Play();
            // 0.05秒待つ
            yield return new WaitForSeconds(_shotDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当たったゲームオブジェクトのLayerの名前を取得
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        //当たったのがBullet(Enemy)かどうかを判定
        if (layername == "Bullet(Enemy)")
        {
            //そうだった場合そのオブジェクトを削除
            Destroy(collision.gameObject);
        }
        //当たったのがBullet(Enemy)、もしくはEnemyかどうかを判定
        if (layername == "Bullet(Enemy)" || layername == "Enemy")
        {
            //爆発のオブジェクト生成
            Explosion();
            //自機を削除
            Destroy(this.gameObject);

            FindObjectOfType<Manager>().GameOver();
        }
    }

    protected override void Move(Vector2 direction)
    {
        //左下のワールド座標
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        //右上のワールド座標
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        //自機の座標
        Vector2 pos = transform.position;

        print(direction);

        // 移動量を加える
        pos += direction * _speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

}
