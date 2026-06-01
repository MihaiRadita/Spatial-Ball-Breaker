using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float screenUnits = 0f;
    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 22f;
    void Start()
    {
        screenUnits = Camera.main.orthographicSize * 2 / Screen.height * Screen.width;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<GameStatus>().gameOver == false)
        {
            float mousePos = Input.mousePosition.x / Screen.width *screenUnits;
            transform.position = new Vector2(Mathf.Clamp(mousePos, minX, maxX), transform.position.y);
        }
    }
}
