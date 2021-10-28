using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public enum DeathAction { LoadLevelWhenDead, DoNothingWhenDead };

    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f;      //base health points

    public int numberOfLives = 1;                   //lives and variables for respawning
    public bool isAlive = true;

    public GameObject explosionPrefab;

    public DeathAction onLivesGone = DeathAction.DoNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;


    // Use this for initialization
    private void Start()
    {
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (LevelToLoad == "") // default to current scene 
        {
            // LevelToLoad = Application.loadedLevelName;
            LevelToLoad = SceneManager.GetActiveScene().ToString();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (healthPoints <= 0)
        {               // if the object is 'dead'
            numberOfLives--;                    // decrement # of lives, update lives GUI

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0)
            { // respawn
                transform.position = respawnPosition;   // reset the player to respawn position
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints; // give the player full health again
            }
            else
            { // here is where you do stuff once ALL lives are gone)
                isAlive = false;

                switch (onLivesGone)
                {
                    case DeathAction.LoadLevelWhenDead:
                        SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
                        break;
                    case DeathAction.DoNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints -= amount;
    }

    public void ApplyHeal(float amount)
    {
        healthPoints += amount;
    }

    public void ApplyBonusLife(int amount)
    {
        numberOfLives += amount;
    }

    public void UpdateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }
}
