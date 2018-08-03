using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    public Transform north;
    public Transform east;
    public Transform west;

    public RedBullet redBullet;
    public BlueBullet blueBullet;
    public int bulletCount;
    private int count; // How many waves of bullets

	public GameObject playerRef;
	private SimplePlatformController3 player;

    public Text gameOverText;

    public string color = "Blue";

	private void Start()
	{
		player = playerRef.GetComponent<SimplePlatformController3>();
		StartCoroutine(Spawn());
	}

    private IEnumerator Spawn()
    {
        while(count < bulletCount)
        {

            if (Random.Range(0, 2) == 0)
            {
                SpawnAtNorth(redBullet);
                SpawnAtEast(redBullet);
                SpawnAtWest(redBullet);
            }
            else
            {
                SpawnAtNorth(blueBullet);
                SpawnAtEast(blueBullet);
                SpawnAtWest(blueBullet);
            }
            count++;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(5);
        gameOverText.GetComponent<Text>().text = "You Win!";
    }
    private void SpawnAtNorth(Bullet bullet)
    {
		Bullet obj = Instantiate (bullet, new Vector3 (Random.Range (-18.0f, 18.0f), north.position.y, -1), Quaternion.Euler (0, 0, -90));
		obj.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-5,0);
    }
    private void SpawnAtEast(Bullet bullet)
    {
		//Debug.Log (bullets.Count);
		Bullet obj = Instantiate(bullet, new Vector3(east.transform.position.x, Random.Range(-9.5f, 22.5f), -1), Quaternion.Euler(0,0,180));
		obj.GetComponent<Rigidbody2D>().velocity = new Vector3(-10,0,0);
    }
    private void SpawnAtWest(Bullet bullet)
    {
		Bullet obj = Instantiate (bullet, new Vector3 (west.transform.position.x, Random.Range (-9.5f, 22.5f), -1), Quaternion.identity);
			obj.GetComponent<Rigidbody2D>().velocity = new Vector3(10,0,0);
    }


}
