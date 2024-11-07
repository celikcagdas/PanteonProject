using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaintingController : MonoBehaviour
{
    public GameObject finishPanel;
    public Renderer wallRenderer;
    public TMP_Text percentageText;
    public Slider sizeSlider;
    public GameObject joystick;

    private PlayerController playerController; 
    private Color selectedColor = Color.white;
    private float paintAmount = 0;
    private bool isPainting = false;
    private Color initialColor;

    void Start()
    {
        finishPanel.SetActive(false);
        initialColor = wallRenderer.material.color;
        playerController = GetComponent<PlayerController>(); 
    }

    void Update()
    {
        if (isPainting)
        {
            Paint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            finishPanel.SetActive(true);
            isPainting = true;
            joystick.SetActive(false);
            DisableCharacterMovement();
        }
    }

    public void SelectColor(int colorIndex)
    {
        switch (colorIndex)
        {
            case 0:
                selectedColor = Color.red;
                break;
            case 1:
                selectedColor = Color.yellow;
                break;
            case 2:
                selectedColor = Color.blue;
                break;
            
               
                
        }
    }

    private void Paint()
    {
        if (paintAmount < 1)
        {
    
            float paintSpeed = sizeSlider.value * 0.01f;
            paintAmount += Time.deltaTime * paintSpeed;
            paintAmount = Mathf.Clamp01(paintAmount); 

            
            wallRenderer.material.color = Color.Lerp(initialColor, selectedColor, paintAmount);

            
            percentageText.text = "%" + (paintAmount * 100).ToString("F0");
        }
        else
        {
            
            percentageText.text = "%100";
            isPainting = false;
            joystick.SetActive(true);
            EnableCharacterMovement();
        }
    }


    private void DisableCharacterMovement()
    {
        if (playerController != null)
        {
            playerController.enabled = false; 
        }
    }

    private void EnableCharacterMovement()
    {
        if (playerController != null)
        {
            playerController.enabled = true; 
        }
    }
}







