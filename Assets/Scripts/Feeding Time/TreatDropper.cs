using UnityEngine;

public class TreatDropper : MonoBehaviour
{
    //Inspector
    [SerializeField] GameObject treat;

    [Header("Dropper Settings")]
    [SerializeField] Transform dropper = null;
    [SerializeField] Transform leftMost = null;
    [SerializeField] Transform rightMost = null;

    //Properties
    float _currentPos = 0.5f;
    float currentPos
    {
        get => _currentPos;
        set
        {
            //Keep the value unit clamped
            if (value > 1f)
            {
                moveRight = false;  //Start moving left
                _currentPos = 1f - Mathf.Abs(value - 1.0f);
            }
            else if (value < 0f)
            {
                moveRight = true;   //Start moving right
                _currentPos = 0f + Mathf.Abs(value);
            }
            else
            {
                _currentPos = value;
            }
        }
    }

    //Members
    public float speed = 0.1f;      //Temp
    public bool moveRight = false;


    void Awake()
    {
        leftMost = transform.Find("Left");
        rightMost = transform.Find("Right");
        dropper = transform.Find("Dropper");
    }

    void Start()
    {
        if (!leftMost || !rightMost || !dropper)
        {
            Debug.LogWarning("Critical object not found. Disabling...");
            enabled = false;
            return;
        }

        //Determine starting direction
        moveRight = (Random.Range(0, 2) == 1) ? true : false;
    }

    void Update()
    {
        UpdateDropperPosition();
    }

    void UpdateDropperPosition()
    {
        //Update current position value
        currentPos += moveRight ? speed * Time.deltaTime : -speed * Time.deltaTime;

        //Update dropper position
        dropper.transform.position = Vector3.Lerp(leftMost.position, rightMost.position, currentPos);
    }

    public void SpawnTreat()
    {
        Instantiate(treat, transform.position, transform.rotation);
    }
}