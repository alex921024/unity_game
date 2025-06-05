using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int HP;
    public Image[] hearts; // 三個Image
    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        UpdateHearts();
        if (HP <= 0)
        {
            PlayerDie();
            Time.timeScale = 0f;
        }
    }

    void UpdateHearts()// 更新心型圖片顯示
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < HP)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    void PlayerDie()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("end", LoadSceneMode.Single);
    }

}