using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public GameObject PlayerCamera;
	public GameObject ComputerCamera;
	public GameObject ComputerUI;
    public GameObject KitchenCamera;
    public GameObject PuzzleThreeCamera;

    public int CamMode;
	// Start is called before the first frame update
	void Start()
	{
		CamMode = 0;
		PlayerCamera.SetActive(true);
		ComputerCamera.SetActive(false);
		ComputerUI.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
    }

	// Update is called once per frame
	void Update()
	{

	}

	public void GoToPlayerCamera()
	{
		PlayerCamera.SetActive(true);
		ComputerCamera.SetActive(false);
		ComputerUI.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
    }

	//IEnumerator PlayerCamSwitch()
	//{
	//	yield return new WaitForSeconds(0.01f);
	//	PlayerCamera.SetActive(true);
	//	ComputerCamera.SetActive(false);
	//}

	public void GoToComputerCamera()
	{
		ComputerUI.SetActive(true);
		PlayerCamera.SetActive(false);
		ComputerCamera.SetActive(true);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
    }

    //IEnumerator ComputerCamSwitch()
    //{
    //	yield return new WaitForSeconds(0.01f);
    //	PlayerCamera.SetActive(true);
    //	ComputerCamera.SetActive(false);
    //}

    public void GoToKitchenCamera()
    {
        ComputerUI.SetActive(false);
        PlayerCamera.SetActive(false);
        ComputerCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        KitchenCamera.SetActive(true);

    }

    public void GoToPuzzleThree()
    {
        ComputerUI.SetActive(false);
        PlayerCamera.SetActive(false);
        ComputerCamera.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(true);

    }
}
