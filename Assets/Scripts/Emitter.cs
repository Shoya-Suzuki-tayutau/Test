using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    // Waveプレハブを格納する
    public GameObject[] waves;

    // 現在のWave
    private int currentWave = 0;

    // Use this for initialization
    IEnumerator Start () {

        //wavesの数がゼロ個の時
        if (waves.Length == 0)
            yield break;

        // Managerコンポーネントをシーン内から探して取得する
        Manager manager = FindObjectOfType<Manager>();

        while (true)
        {

            while(manager.IsPlay() == false)
            {
                yield return new WaitForEndOfFrame();
            }
            GameObject wave = Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            wave.transform.parent = transform;

            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);

            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
