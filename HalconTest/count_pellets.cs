//
// File generated by HDevelop for HALCON/.NET (C#) Version 13.0
//

using HalconDotNet;

public partial class HDevelopExport
{
#if !(NO_EXPORT_MAIN || NO_EXPORT_APP_MAIN)
  public HDevelopExport()
  {
    // Default settings used in HDevelop 
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
    if (HalconAPI.isWindows)
      HOperatorSet.SetSystem("use_window_thread","true");
    action();
  }
#endif

  // Procedures 
  // External procedures 
  // Chapter: Develop
  // Short Description: Switch dev_update_pc, dev_update_var and dev_update_window to 'off'. 
  public void dev_update_off ()
  {

    // Initialize local and output iconic variables 
    //This procedure sets different update settings to 'off'.
    //This is useful to get the best performance and reduce overhead.
    //
    // dev_update_pc(...); only in hdevelop
    // dev_update_var(...); only in hdevelop
    // dev_update_window(...); only in hdevelop

    return;
  }

  // Chapter: Graphics / Text
  // Short Description: This procedure displays 'Click 'Run' to continue' in the lower right corner of the screen. 
  public void disp_continue_message (HTuple hv_WindowHandle, HTuple hv_Color, HTuple hv_Box)
  {



    // Local iconic variables 

    // Local control variables 

    HTuple hv_GenParamName = null, hv_GenParamValue = null;
    HTuple hv_ContinueMessage = null;
    HTuple   hv_Color_COPY_INP_TMP = hv_Color.Clone();

    // Initialize local and output iconic variables 
    //This procedure displays 'Press Run (F5) to continue' in the
    //lower right corner of the screen.
    //It uses the procedure disp_message.
    //
    //Input parameters:
    //WindowHandle: The window, where the text shall be displayed
    //Color: defines the text color.
    //   If set to '' or 'auto', the currently set color is used.
    //Box: If set to 'true', the text is displayed in a box.
    //
    //Convert the parameter Box to generic parameters.
    hv_GenParamName = new HTuple();
    hv_GenParamValue = new HTuple();
    if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
    {
      if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
      {
        //Display no box
        hv_GenParamName = hv_GenParamName.TupleConcat("box");
        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
      }
      else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual("true"))) != 0)
      {
        //Set a color other than the default.
        hv_GenParamName = hv_GenParamName.TupleConcat("box_color");
        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(0));
      }
    }
    if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
    {
      if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
      {
        //Display no shadow.
        hv_GenParamName = hv_GenParamName.TupleConcat("shadow");
        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
      }
      else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual("true"))) != 0)
      {
        //Set a shadow color other than the default.
        hv_GenParamName = hv_GenParamName.TupleConcat("shadow_color");
        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(1));
      }
    }
    //
    if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
    {
      //disp_text does not accept an empty string for Color.
      hv_Color_COPY_INP_TMP = new HTuple();
    }
    //
    //Display the message.
    hv_ContinueMessage = "Press Run (F5) to continue";
    HOperatorSet.DispText(hv_WindowHandle, hv_ContinueMessage, "window", "bottom", 
        "right", hv_Color_COPY_INP_TMP, hv_GenParamName, hv_GenParamValue);

    return;
  }

  // Chapter: Graphics / Text
  // Short Description: This procedure writes a text message. 
  public void disp_message (HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem, 
      HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
  {



    // Local iconic variables 

    // Local control variables 

    HTuple hv_GenParamName = null, hv_GenParamValue = null;
    HTuple   hv_Color_COPY_INP_TMP = hv_Color.Clone();
    HTuple   hv_Column_COPY_INP_TMP = hv_Column.Clone();
    HTuple   hv_CoordSystem_COPY_INP_TMP = hv_CoordSystem.Clone();
    HTuple   hv_Row_COPY_INP_TMP = hv_Row.Clone();

    // Initialize local and output iconic variables 
    //This procedure displays text in a graphics window.
    //
    //Input parameters:
    //WindowHandle: The WindowHandle of the graphics window, where
    //   the message should be displayed
    //String: A tuple of strings containing the text message to be displayed
    //CoordSystem: If set to 'window', the text position is given
    //   with respect to the window coordinate system.
    //   If set to 'image', image coordinates are used.
    //   (This may be useful in zoomed images.)
    //Row: The row coordinate of the desired text position
    //   A tuple of values is allowed to display text at different
    //   positions.
    //Column: The column coordinate of the desired text position
    //   A tuple of values is allowed to display text at different
    //   positions.
    //Color: defines the color of the text as string.
    //   If set to [], '' or 'auto' the currently set color is used.
    //   If a tuple of strings is passed, the colors are used cyclically...
    //   - if |Row| == |Column| == 1: for each new textline
    //   = else for each text position.
    //Box: If Box[0] is set to 'true', the text is written within an orange box.
    //     If set to' false', no box is displayed.
    //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
    //       the text is written in a box of that color.
    //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
    //       'true' -> display a shadow in a default color
    //       'false' -> display no shadow
    //       otherwise -> use given string as color string for the shadow color
    //
    //It is possible to display multiple text strings in a single call.
    //In this case, some restrictions apply:
    //- Multiple text positions can be defined by specifying a tuple
    //  with multiple Row and/or Column coordinates, i.e.:
    //  - |Row| == n, |Column| == n
    //  - |Row| == n, |Column| == 1
    //  - |Row| == 1, |Column| == n
    //- If |Row| == |Column| == 1,
    //  each element of String is display in a new textline.
    //- If multiple positions or specified, the number of Strings
    //  must match the number of positions, i.e.:
    //  - Either |String| == n (each string is displayed at the
    //                          corresponding position),
    //  - or     |String| == 1 (The string is displayed n times).
    //
    //
    //Convert the parameters for disp_text.
    if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
        new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
    {

      return;
    }
    if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
    {
      hv_Row_COPY_INP_TMP = 12;
    }
    if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
    {
      hv_Column_COPY_INP_TMP = 12;
    }
    //
    //Convert the parameter Box to generic parameters.
    hv_GenParamName = new HTuple();
    hv_GenParamValue = new HTuple();
    if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
    {
      if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
      {
        //Display no box
        hv_GenParamName = hv_GenParamName.TupleConcat("box");
        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
      }
      else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual("true"))) != 0)
      {
        //Set a color other than the default.
        hv_GenParamName = hv_GenParamName.TupleConcat("box_color");
        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(0));
      }
    }
    if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
    {
      if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
      {
        //Display no shadow.
        hv_GenParamName = hv_GenParamName.TupleConcat("shadow");
        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
      }
      else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual("true"))) != 0)
      {
        //Set a shadow color other than the default.
        hv_GenParamName = hv_GenParamName.TupleConcat("shadow_color");
        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(1));
      }
    }
    //Restore default CoordSystem behavior.
    if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
    {
      hv_CoordSystem_COPY_INP_TMP = "image";
    }
    //
    if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
    {
      //disp_text does not accept an empty string for Color.
      hv_Color_COPY_INP_TMP = new HTuple();
    }
    //
    HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP, 
        hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName, 
        hv_GenParamValue);

    return;
  }

  // Chapter: Graphics / Text
  // Short Description: Set font independent of OS 
  public void set_display_font (HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, 
      HTuple hv_Bold, HTuple hv_Slant)
  {



    // Local iconic variables 

    // Local control variables 

    HTuple hv_OS = null, hv_Fonts = new HTuple();
    HTuple hv_Style = null, hv_Exception = new HTuple(), hv_AvailableFonts = null;
    HTuple hv_Fdx = null, hv_Indices = new HTuple();
    HTuple   hv_Font_COPY_INP_TMP = hv_Font.Clone();
    HTuple   hv_Size_COPY_INP_TMP = hv_Size.Clone();

    // Initialize local and output iconic variables 
    //This procedure sets the text font of the current window with
    //the specified attributes.
    //
    //Input parameters:
    //WindowHandle: The graphics window for which the font will be set
    //Size: The font size. If Size=-1, the default of 16 is used.
    //Bold: If set to 'true', a bold font is used
    //Slant: If set to 'true', a slanted font is used
    //
    HOperatorSet.GetSystem("operating_system", out hv_OS);
    // dev_get_preferences(...); only in hdevelop
    // dev_set_preferences(...); only in hdevelop
    if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
        new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
    {
      hv_Size_COPY_INP_TMP = 16;
    }
    if ((int)(new HTuple(((hv_OS.TupleSubstr(0,2))).TupleEqual("Win"))) != 0)
    {
      //Restore previous behaviour
      hv_Size_COPY_INP_TMP = ((1.13677*hv_Size_COPY_INP_TMP)).TupleInt();
    }
    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
    {
      hv_Fonts = new HTuple();
      hv_Fonts[0] = "Courier";
      hv_Fonts[1] = "Courier 10 Pitch";
      hv_Fonts[2] = "Courier New";
      hv_Fonts[3] = "CourierNew";
    }
    else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
    {
      hv_Fonts = new HTuple();
      hv_Fonts[0] = "Consolas";
      hv_Fonts[1] = "Menlo";
      hv_Fonts[2] = "Courier";
      hv_Fonts[3] = "Courier 10 Pitch";
      hv_Fonts[4] = "FreeMono";
    }
    else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
    {
      hv_Fonts = new HTuple();
      hv_Fonts[0] = "Luxi Sans";
      hv_Fonts[1] = "DejaVu Sans";
      hv_Fonts[2] = "FreeSans";
      hv_Fonts[3] = "Arial";
    }
    else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
    {
      hv_Fonts = new HTuple();
      hv_Fonts[0] = "Times New Roman";
      hv_Fonts[1] = "Luxi Serif";
      hv_Fonts[2] = "DejaVu Serif";
      hv_Fonts[3] = "FreeSerif";
      hv_Fonts[4] = "Utopia";
    }
    else
    {
      hv_Fonts = hv_Font_COPY_INP_TMP.Clone();
    }
    hv_Style = "";
    if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
    {
      hv_Style = hv_Style+"Bold";
    }
    else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
    {
      hv_Exception = "Wrong value of control parameter Bold";
      throw new HalconException(hv_Exception);
    }
    if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
    {
      hv_Style = hv_Style+"Italic";
    }
    else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
    {
      hv_Exception = "Wrong value of control parameter Slant";
      throw new HalconException(hv_Exception);
    }
    if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
    {
      hv_Style = "Normal";
    }
    HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
    hv_Font_COPY_INP_TMP = "";
    for (hv_Fdx=0; (int)hv_Fdx<=(int)((new HTuple(hv_Fonts.TupleLength()))-1); hv_Fdx = (int)hv_Fdx + 1)
    {
      hv_Indices = hv_AvailableFonts.TupleFind(hv_Fonts.TupleSelect(hv_Fdx));
      if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(0))) != 0)
      {
        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
        {
          hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_Fdx);
          break;
        }
      }
    }
    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
    {
      throw new HalconException("Wrong value of control parameter Font");
    }
    hv_Font_COPY_INP_TMP = (((hv_Font_COPY_INP_TMP+"-")+hv_Style)+"-")+hv_Size_COPY_INP_TMP;
    HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);
    // dev_set_preferences(...); only in hdevelop

    return;
  }

#if !NO_EXPORT_MAIN
  // Main procedure 
  private void action()
  {


    // Local iconic variables 

    HObject ho_Image, ho_LightRegion, ho_Region;
    HObject ho_ConnectedRegionsWrong, ho_RegionErosion, ho_ConnectedRegions;
    HObject ho_RegionDilation;

    // Local control variables 

    HTuple hv_Width = null, hv_Height = null, hv_WindowID = null;
    HTuple hv_UsedThreshold = null, hv_Number = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image);
    HOperatorSet.GenEmptyObj(out ho_LightRegion);
    HOperatorSet.GenEmptyObj(out ho_Region);
    HOperatorSet.GenEmptyObj(out ho_ConnectedRegionsWrong);
    HOperatorSet.GenEmptyObj(out ho_RegionErosion);
    HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
    HOperatorSet.GenEmptyObj(out ho_RegionDilation);
    try
    {
      //This programs demonstrates the use of basic morphology
      //operators.
      //The aim of the program is to detect each single pellet
      //(bright particle on a darker background).
      //
      dev_update_off();
      ho_Image.Dispose();
      //HOperatorSet.ReadImage(out ho_Image, "pellets"); //Total number is 57
      HOperatorSet.ReadImage(out ho_Image, @".\images\test1.png");
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.CloseWindow(HDevWindowStack.Pop());
      }
      HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
      HOperatorSet.SetWindowAttr("background_color","black");
      HOperatorSet.OpenWindow(0,0,hv_Width,hv_Height,0,"visible","",out hv_WindowID);
      HDevWindowStack.Push(hv_WindowID);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, hv_Height-1, hv_Width-1);
      }
      set_display_font(hv_WindowID, 16, "mono", "true", "false");
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetColored(HDevWindowStack.GetActive(), 3);
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 3);
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }

      HObject FinalBalls;

        /*HObject light;
        HOperatorSet.Threshold(ho_Image,out light,180,220);
        HOperatorSet.DispObj(light, HDevWindowStack.GetActive());
        HOperatorSet.CountObj(light, out hv_Number);

        HObject connection;
        HOperatorSet.Connection(light, out connection);
        HOperatorSet.CountObj(connection, out hv_Number);*/

        HObject gray_Image;
        HOperatorSet.Rgb1ToGray(ho_Image, out gray_Image);
        HOperatorSet.DispObj(gray_Image, HDevWindowStack.GetActive());

        HOperatorSet.FastThreshold(gray_Image, out ho_LightRegion, 160, 245, 12);
        
        /*HOperatorSet.BinaryThreshold(ho_Image, out ho_LightRegion, "max_separability",
    "light", out hv_UsedThreshold);*/
        HOperatorSet.DispObj(ho_LightRegion, HDevWindowStack.GetActive());

        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
        HOperatorSet.OpeningRectangle1(ho_LightRegion, out ho_Region, 6, 7);
        HOperatorSet.DispObj(ho_Region, HDevWindowStack.GetActive());
        HOperatorSet.Connection(ho_Region, out ho_ConnectedRegionsWrong);
        HOperatorSet.CountObj(ho_ConnectedRegionsWrong, out hv_Number);

        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
        HOperatorSet.ErosionRectangle1(ho_Region, out ho_RegionErosion, 5.5, 6.5);
        HOperatorSet.DispObj(ho_RegionErosion, HDevWindowStack.GetActive());

        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
        HOperatorSet.Connection(ho_Region, out ho_ConnectedRegionsWrong);
        HOperatorSet.DispObj(ho_ConnectedRegionsWrong, HDevWindowStack.GetActive());
        
        HOperatorSet.SelectShape(ho_ConnectedRegionsWrong, out FinalBalls, new HTuple("area"), "or", new HTuple(1), new HTuple(99999));
        HOperatorSet.CountObj(FinalBalls, out hv_Number);

        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());

        for (int i = 0; i < hv_Number.I; i++)
        {
            HObject ObjectSelected;
            HOperatorSet.SelectObj(FinalBalls, out ObjectSelected, i + 1);
            HOperatorSet.DispObj(ObjectSelected, HDevWindowStack.GetActive());
        }

        HOperatorSet.CountObj(ho_LightRegion, out hv_Number);

        

        /*HOperatorSet.BinaryThreshold(ho_Image, out ho_LightRegion, "max_separability",
            "light", out hv_UsedThreshold);
        //HOperatorSet.OverpaintRegion(ho_Image, ho_LightRegion, new HTuple(0,255,0), "fill");
        HOperatorSet.DispObj(ho_LightRegion, HDevWindowStack.GetActive());*/
       HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());

        HObject roberts;
        HOperatorSet.Roberts(ho_Image, out roberts, "roberts_max");
        //HOperatorSet.OverpaintRegion(ho_Image, roberts, new HTuple(255, 0, 0), "fill");
        HOperatorSet.DispObj(roberts, HDevWindowStack.GetActive());

        
        HObject ed_Image;
        /*HOperatorSet.EdgesSubPix(ho_Image, out ed_Image,"canny",0.5,20,40);
        HOperatorSet.DispObj(ed_Image, HDevWindowStack.GetActive());
        //HOperatorSet.Connection(ed_Image, out ho_ConnectedRegionsWrong);
        HOperatorSet.CountObj(ed_Image, out hv_Number);*/        

        // 1 lin = 25.4 mm
        HOperatorSet.BinaryThreshold(ho_Image, out ho_LightRegion, "max_separability",
    "light", out hv_UsedThreshold);

        HOperatorSet.OpeningRectangle1(ho_LightRegion, out ho_Region, 0.5, 4);
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());       

        HOperatorSet.Connection(ho_Region, out ho_ConnectedRegionsWrong);
        HOperatorSet.DispObj(ho_ConnectedRegionsWrong, HDevWindowStack.GetActive());
        HOperatorSet.CountObj(ho_ConnectedRegionsWrong, out hv_Number);  

        HOperatorSet.SelectShape(ho_ConnectedRegionsWrong, out FinalBalls, "rectangularity", "and", new HTuple(0.5), new HTuple(4));
        HOperatorSet.CountObj(FinalBalls, out hv_Number);
        HOperatorSet.DispObj(FinalBalls, HDevWindowStack.GetActive());

        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());

        for (int i = 0; i < hv_Number.I; i++)
        {
            HObject ObjectSelected;
            HOperatorSet.SelectObj(FinalBalls, out ObjectSelected, i+1);            
            HOperatorSet.DispObj(ObjectSelected, HDevWindowStack.GetActive());
        }


        HOperatorSet.ErosionRectangle1(ho_Region, out ho_RegionErosion, 8, 1);
        HOperatorSet.DispObj(ho_RegionErosion, HDevWindowStack.GetActive());

        HOperatorSet.Connection(ho_RegionErosion, out ho_ConnectedRegions);
        HOperatorSet.DispObj(ho_ConnectedRegions, HDevWindowStack.GetActive());

        HOperatorSet.DilationRectangle1(ho_ConnectedRegions, out ho_RegionDilation, 7.5, 1);
        HOperatorSet.DispObj(ho_RegionDilation, HDevWindowStack.GetActive());

        HOperatorSet.CountObj(ho_RegionDilation, out hv_Number);

        System.Console.WriteLine(hv_Number.I);

        return;
        /*HObject l, d;

        HOperatorSet.SegmentImageMser(ho_Image, out d, out l, "light", 10, new HTuple(), 15, new HTuple(), new HTuple());

        HOperatorSet.DispObj(l, HDevWindowStack.GetActive());

        HOperatorSet.DispObj(d, HDevWindowStack.GetActive());*/

      //disp_message(hv_WindowID, "Detect each single pellet", "window", 12, 12, "black", 
      //    "true");
      //disp_continue_message(hv_WindowID, "black", "true");
      
      // stop(...); only in hdevelop
      //
      //Segment the regions of the pellets from the background

      /*ho_LightRegion.Dispose();
      HOperatorSet.BinaryThreshold(gray_Image, out ho_LightRegion, "max_separability",
          "light", out hv_UsedThreshold);
      ho_Region.Dispose();*/

        HTuple hv_color = new HTuple(0,0,0);

      //HOperatorSet.GenImageConst(out ho_Region, "byte", 768, 576);

      HOperatorSet.OverpaintRegion(ho_Image, ho_LightRegion, hv_color, "fill");

      //HOperatorSet.FastThreshold(ho_Image, out ho_LightRegion, 200, 255, 30);

      if (HDevWindowStack.IsOpen())
      {
          HOperatorSet.DispObj(ho_LightRegion, HDevWindowStack.GetActive());
      }

      //HOperatorSet.OpeningCircle(ho_LightRegion, out ho_Region, 3.5);
      HOperatorSet.OpeningRectangle1(ho_LightRegion, out ho_Region, 8, 6);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_LightRegion, HDevWindowStack.GetActive());
      }

      //disp_message(hv_WindowID, new HTuple("First, segment the pellets"), "window", 
      //    12, 12, "black", "true");
      //disp_continue_message(hv_WindowID, "black", "true");

      // stop(...); only in hdevelop
      //
      //Compute the connected pellet regions
      //Note, that this approach fails, because some of
      //the pellets are still connected.
      ho_ConnectedRegionsWrong.Dispose();
      HOperatorSet.Connection(ho_Region, out ho_ConnectedRegionsWrong);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_ConnectedRegionsWrong, HDevWindowStack.GetActive()
            );
      }

      //disp_message(hv_WindowID, "Simple connection fails", "window", 12, 12, "black", 
      //    "true");
      //disp_continue_message(hv_WindowID, "black", "true");

      // stop(...); only in hdevelop
      //
      //Separate each pellet from the others by erosion
      ho_RegionErosion.Dispose();
      //HOperatorSet.ErosionCircle(ho_Region, out ho_RegionErosion, 7.5);
      HOperatorSet.ErosionRectangle1(ho_Region, out ho_RegionErosion, 8, 6);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_RegionErosion, HDevWindowStack.GetActive());
      }

      //disp_message(hv_WindowID, "Erosion of the pellet regions", "window", 12, 12, 
      //    "black", "true");
      //disp_continue_message(hv_WindowID, "black", "true");

      // stop(...); only in hdevelop
      //
      //Now, compute the connected pellet regions
      ho_ConnectedRegions.Dispose();
      HOperatorSet.Connection(ho_RegionErosion, out ho_ConnectedRegions);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_ConnectedRegions, HDevWindowStack.GetActive());
      }

      //disp_message(hv_WindowID, "Perform connection now", "window", 12, 12, "black", 
      //    "true");
      //disp_continue_message(hv_WindowID, "black", "true");

      // stop(...); only in hdevelop
      //
      //Turn back to the original pellet size by applying a dilation
      ho_RegionDilation.Dispose();
      //HOperatorSet.DilationCircle(ho_ConnectedRegions, out ho_RegionDilation, 7.5);
      HOperatorSet.DilationRectangle1(ho_ConnectedRegions, out ho_RegionDilation, 7.5, 4.5);
      HOperatorSet.CountObj(ho_RegionDilation, out hv_Number);

      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_RegionDilation, HDevWindowStack.GetActive());
      }
      disp_message(hv_WindowID, hv_Number+" pellets detected", "window", 12, 12, 
          "black", "true");
    }
    catch (HalconException HDevExpDefaultException)
    {
      ho_Image.Dispose();
      ho_LightRegion.Dispose();
      ho_Region.Dispose();
      ho_ConnectedRegionsWrong.Dispose();
      ho_RegionErosion.Dispose();
      ho_ConnectedRegions.Dispose();
      ho_RegionDilation.Dispose();

      throw HDevExpDefaultException;
    }
    ho_Image.Dispose();
    ho_LightRegion.Dispose();
    ho_Region.Dispose();
    ho_ConnectedRegionsWrong.Dispose();
    ho_RegionErosion.Dispose();
    ho_ConnectedRegions.Dispose();
    ho_RegionDilation.Dispose();

  }

#endif


}


