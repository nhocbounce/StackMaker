using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    //public const int DOWN = 2;
    //public const int LEFT = 4;
    //public const int RIGHT = 6;
    //public const int UP = 8;
    public const int INPUTTHRESHOLD = 25;
    public const int WALLLAYERMASK = 1<<8;

    public const float ARRIVEDOFFSET = 0.0001f;
    public const float MOVABLEOFFSET = 0.7f;
    public const float TRUEPOSITIONOFFSET = 0.5f;
    public const float DELAYSHOWINGUI = 1f;
    public const float MODELHEIGHTOFFSET = 0.05f;
    public const float STACKINGBLOCKTHICKNESS = 0.2f;
    



    public const string LEVELPATH = "Levels/Level ";
    public const string LEVELTEMPLATEPATH = "Levels/LevelTemplate";
    public const string RESOURCESFOLDER = "Assets/Gameplay/Resources/";
    public const string PREFABEXTENSION = ".prefab";



    public const string PLAYER = "Player";
    public const string EDIBLE = "Edible";
    public const string INEDIBLE = "Inedible";
    public const string WIN = "Win";
}
