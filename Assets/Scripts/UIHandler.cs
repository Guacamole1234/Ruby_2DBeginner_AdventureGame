using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; } /*The get property is public and static. You can write UIHandler.instance in any script within your Unity project and it will call the get property.  The set property is private; you should only be able to change the instance property within the UIHandler script.*/
    private VisualElement m_Healthbar;

    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar"); /*The root of the UI Hierarchy is accessed through rootVisualElement. As you’ve encountered previously, the VisualElement is accessed using the dot operator. The Q function is short for Query. You can use this function to find a particular VisualElement in the Hierarchy window that matches multiple search parameters — in this case you are using the element name.  Query is a generic function, because you can use it to query lots of different types. The specific type you are looking for is provided in angle brackets — in this case, it’s a VisualElement named “HealthBar”.  Note: GetComponent, which you’ve used previously, is also a generic function: you can use it to get any kind of component, but you need to specify which one you need when you use the function.*/
        SetHealthValue(1f);

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }
    public void SetHealthValue (float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage); /*style contains all the VisualElement properties that you can set with UI Builder, and it is the width that you are resizing with this instruction. The special function Length defines a size in Percent (one of the various size types available for the property). Note: If you provide a value to the Width property directly, the UI Toolkit system will interpret it as a pixel size rather than a percentage.*/
    }

    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }


}
