using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PauseManager pauseControl = new PauseManager();

    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    public Text ScoreText;
    public Text LivesText;
    public Text LoseText;
    public GameObject loseRestartButton;

    private int count = 0;
    private int lives = 3;
    private double timestamp = 0;

    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 10;
            Debug.Log("Hit! " + count);
            ScoreText.text = "Score: " + count;
        }

        if (other.gameObject.tag == "Predator")
        {
            if (timestamp <= Time.time)
            {
                lives -= 1;
                Debug.Log("Attacked " + lives);
                timestamp = Time.time + 3.0;
                LivesText.text = "Lives: " + lives;
            }
        }

        if (count >= 30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        if (lives <= 0)
        {
            LoseText.gameObject.SetActive(true);
            loseRestartButton.gameObject.SetActive(true);
            pauseControl.pauseControl();

        }
    }
}