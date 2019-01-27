using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ContenxtInfo
{

    private static float leftBorder;
    private static float rightBorder;
    private static float topBorder;
    private static float bottomBorder;

    public static float LeftBorder
    {
        get { return leftBorder; }
        set { leftBorder = value; }
    }

    public static float RightBorder
    {
        get { return rightBorder; }
        set { rightBorder = value; }
    }

    public static float TopBorder
    {
        get { return topBorder; }
        set { topBorder = value; }
    }

    public static float BottomBorder
    {
        get { return bottomBorder; }
        set { bottomBorder = value; }
    }

}

