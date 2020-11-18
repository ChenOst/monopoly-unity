using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    [SerializeField] [Tooltip("The Animation of the Dice Body")]
    private RollAnimation _animation;

    // The name of the wanted collider object
    private readonly string _expectedColliderName = "Dice Collider";
    public int rollResult { get; private set; }

    public bool diceWasRolled { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        Roll();
    }

    private void Roll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            // Activate only if Dice Collider was hit
            if (hit.collider != null && hit.collider.name.Equals(_expectedColliderName) && !diceWasRolled)
            {
                // Can't roll more then once
                diceWasRolled = true;

                // Get number between 1-6
                rollResult = Random.Range(1, 7);

                // Active Roll The Dice animation
                _animation.PlayAnimation();
            }
        }
    }

    // Reset at the end of the turn
    public void ResetRoll()
    {
        diceWasRolled = false;
        rollResult = 0;
    }
}