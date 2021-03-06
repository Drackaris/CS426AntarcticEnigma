﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public GameObject PlayerCamera;
	public GameObject ComputerCamera;
	public GameObject ComputerUI;
	public GameObject PlayerUI;
    public GameObject KitchenCamera;
    public GameObject PuzzleThreeCamera;
    public GameObject PuzzleFourCamera;

    public int CamMode;
    // Start is called before the first frame update
    void Start()
    {
        CamMode = 0;
        PlayerCamera.SetActive(true);
        PlayerUI.SetActive(true);
        ComputerCamera.SetActive(false);
        ComputerUI.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        PuzzleFourCamera.SetActive(false);
    }

	// Update is called once per frame
	void Update()
	{

	}

	public void GoToPlayerCamera()
	{
		PlayerCamera.SetActive(true);
		PlayerUI.SetActive(true);
		ComputerCamera.SetActive(false);
		ComputerUI.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        PuzzleFourCamera.SetActive(false);
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
		PlayerUI.SetActive(false);
		PlayerCamera.SetActive(false);
		ComputerCamera.SetActive(true);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        PuzzleFourCamera.SetActive(false);
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
		PlayerUI.SetActive(false);
		PlayerCamera.SetActive(false);
        ComputerCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        KitchenCamera.SetActive(true);
        PuzzleFourCamera.SetActive(false);
    }

    public void GoToPuzzleThree()
    {
        ComputerUI.SetActive(false);
		PlayerUI.SetActive(false);
		PlayerCamera.SetActive(false);
        ComputerCamera.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(true);
        PuzzleFourCamera.SetActive(false);
    }

    public void GoToPuzzleFour()
    {
        ComputerUI.SetActive(false);
        PlayerUI.SetActive(false);
        PlayerCamera.SetActive(false);
        ComputerCamera.SetActive(false);
        KitchenCamera.SetActive(false);
        PuzzleThreeCamera.SetActive(false);
        PuzzleFourCamera.SetActive(true);
    }
}
