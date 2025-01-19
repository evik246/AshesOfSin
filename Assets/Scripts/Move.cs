using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class Move : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
        direction = Vector2.zero;   //обнуление вектора движения

        //горизонтальный вектор
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            direction.x = -1;                                                      //движение влево
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x = 1;                                                       //движение вправо
        }

        //вертикальный вектор
        if(Input.GetKey(KeyCode.UpArrow)  || Input.GetKey(KeyCode.W))
        {
            direction.y = 1;                                                       //движение вверх
        }    
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y = -1;                                                      //движение вниз
        } 

        //препятствие диагональному передвижению
        if(direction.x != 0)
        {
            direction.y = 0;                                                       //обнуление вертикального вектора
        }
        else if(direction.y != 0)
        {
            direction.x = 0;                                                       //обнуление горизонтального вектора
        }
        
    }    

    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

}
