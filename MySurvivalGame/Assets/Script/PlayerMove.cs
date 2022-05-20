using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public Transform player;
    public float speed;
    [SerializeField] float speedRotation;
    private RaycastHit touchPointMouse;
    private Vector3 pointMove;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            OnClickPlane();
        }
        Move();
    }

    private void OnClickPlane()
    {
        //запускаем луч с центра камеры в сторону косания мыши
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out touchPointMouse))
        {
            if (touchPointMouse.collider.tag == "Plane")
                pointMove = touchPointMouse.point; 
        }

    }
    private void Move()
    {
        if (pointMove != null && pointMove != player.position)
        {
            player.position = Vector3.MoveTowards(player.position, pointMove, speed * Time.deltaTime);
            PlayerRotate(pointMove, player);
        }
    }
    private void PlayerRotate(Vector3 _pointMove, Transform target)
    {

        transform.rotation = Quaternion.Slerp(target.rotation, Quaternion.Euler(_pointMove), speedRotation * Time.deltaTime);
    }
}
