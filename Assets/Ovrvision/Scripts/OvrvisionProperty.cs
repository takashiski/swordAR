using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[System.Serializable]
public class OvrvisionProperty {

    //OVRVISION Dll import
    //ovrvision_csharp.cpp
    [DllImport("ovrvision", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    static extern void SaveParamXMLtoTempFile(int[] config1, double[] config2);

	//properties
    public int exposure;
    public int whitebalance;
	public int contrast;
	public int saturation;
	public int brightness;
	public int sharpness;
	public int gamma;
    public double IPDHorizontal;
    public double IPDVertical;

    private const int OV_SET_AUTOMODE = (-1);

	//initialize value
	public OvrvisionProperty()
	{
        //Default
        DefaultConfig();
	}

    //config reset
    public void DefaultConfig()
    {
        //Default
        exposure = OV_SET_AUTOMODE;
        whitebalance = OV_SET_AUTOMODE;
        contrast = 32;
        saturation = 40;
        brightness = 100;
        sharpness = 2;
        gamma = 7;
        IPDHorizontal = 0.0;
        IPDVertical = 0.0;
    }

    //Save initialize config datas.
    public void AwakePropSaveToXML()
    {
        int[] config1 = new int[7];
        double[] config2 = new double[2];

        //set data
        config1[0] = exposure;
        config1[1] = whitebalance;
        config1[2] = contrast;
        config1[3] = saturation;
        config1[4] = brightness;
        config1[5] = sharpness;
        config1[6] = gamma;

        config2[0] = IPDHorizontal;
        config2[1] = IPDVertical;

        //save
        SaveParamXMLtoTempFile(config1, config2);
    }
}
