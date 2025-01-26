using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = Vector2.zero;   //Обнуление вектора движения

        //Горизонтальный вектор
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x = -1;                                                      //Движение влево
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x = 1;                                                       //Движение вправо
        }

        //Вертикальный вектор
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction.y = 1;                                                       //Движение вверх
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y = -1;                                                      //Движение вниз
        }

        //Препятствие диагональному передвижению

        if (direction.x != 0)
        {
            direction.y = 0;                                                       //Обнуление вертикального вектора
        }
        else if (direction.y != 0)
        {
            direction.x = 0;                                                       //Обнуление горизонтального вектора
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}