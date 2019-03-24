using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax; // Переменные для обозначения границ по оси х.
}

public class Platform : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 playerPos = new Vector3(0, -10f, 0);
    public Boundary boundary;

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        playerPos = new Vector3(Mathf.Clamp(xPos, boundary.xMin, boundary.xMax), -10f, 0f);
        transform.position = playerPos;
    }

    /*private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Получаем информации о нажатии игроком стрелок "лево" "право" и кнопок "a" и "d".

        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0f, 0f) * speed; // Создаём вектор направления перемещения
                                                                                          // и умножаем на скорость.

        GetComponent<Rigidbody>().position = new Vector3 // Изменяем положение в пространстве.
            (
               Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), // Ограничиваем перемещение по Х минимум и максимумом.
               -10.0f,                                                                          // Y
               0.0f                                                                             // Z
            );
    }*/
}
