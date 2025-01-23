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
        direction = Vector2.zero;   //��������� ������� ��������

        //�������������� ������
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            direction.x = -1;                                                      //�������� �����
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x = 1;                                                       //�������� ������
        }

        //������������ ������
        if(Input.GetKey(KeyCode.UpArrow)  || Input.GetKey(KeyCode.W))
        {
            direction.y = 1;                                                       //�������� �����
        }    
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y = -1;                                                      //�������� ����
        } 

        //����������� ������������� ������������
        if(direction.x != 0)
        {
            direction.y = 0;                                                       //��������� ������������� �������
        }
        else if(direction.y != 0)
        {
            direction.x = 0;                                                       //��������� ��������������� �������
        }
        
    }    

    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

}
