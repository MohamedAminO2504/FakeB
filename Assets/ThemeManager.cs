using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ThemeManager : MonoBehaviour
{
    public Theme theme;
    public Theme defaultTheme;
    public List<RawImage> mascottes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(theme != null){
            initTheme(theme);
        }
    }

    public void initTheme(Theme theme){
        foreach (var item in mascottes)
        {
            item.texture = theme.img.texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
