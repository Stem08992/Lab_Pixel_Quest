
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonActions : MonoBehaviour
{
    public UIDocument uiDocument;

    void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        root.Q<Button>("btn0").clicked += () => NumberClicked(0);
        root.Q<Button>("btn1").clicked += () => NumberClicked(1);
        root.Q<Button>("btn2").clicked += () => NumberClicked(2);
        root.Q<Button>("btn3").clicked += () => NumberClicked(3);
        root.Q<Button>("btn4").clicked += () => NumberClicked(4);
        root.Q<Button>("btn5").clicked += () => NumberClicked(5);
        root.Q<Button>("btn6").clicked += () => NumberClicked(6);
        root.Q<Button>("btn7").clicked += () => NumberClicked(7);
        root.Q<Button>("btn8").clicked += () => NumberClicked(8);
        root.Q<Button>("btn9").clicked += () => NumberClicked(9);
        root.Q<Button>("btnsetting").clicked += settingClicked;
        root.Q<Button>("btnSuper").clicked += SuperClicked;
        root.Q<Button>("btnpause").clicked += pauseClicked;
        root.Q<Button>("btnheart").clicked += heartClicked;
        root.Q<Button>("btnhint").clicked += hintClicked;
        root.Q<Button>("btncheck").clicked += checkClicked;
        root.Q<Button>("btnx").clicked += xClicked;
        root.Q<Button>("btnrun").clicked += runClicked;
    }

    void NumberClicked(int number)
    {
        Debug.Log("You clicked: " + number);
    }
    void runClicked()
    {
        Debug.Log("run button clicked!");
    }
    void xClicked()
    {
        Debug.Log("x button clicked!");
    }
    void checkClicked()
    {
        Debug.Log("check button clicked!");
    }
    void hintClicked()
    {
        Debug.Log("hint button clicked!");
    }
    void heartClicked()
    {
        Debug.Log("heart button clicked!");
    }
    void SuperClicked()
    {
        Debug.Log("SUPER button clicked!");
    }
    void pauseClicked()
    {
        Debug.Log("pause button clicked!");
    }
    void settingClicked()
    {
        Debug.Log("setting button clicked!");
    }


}
