using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Dice
{
    public const string DEGAT = "DEG", ALTERATION = "ALT", EFFECT = "EFF";
    private string name;
    public string Name { get { return name; }set { name = value; } }

    private int face;
    public int Face { get { return face; }set { face = value; } }

    private string[] typeFace;
    public string[] TypeFace { get { return typeFace; } set { typeFace = value; } }

    private string[] faceValue;
    public string[] FaceValue { get { return faceValue; } set { faceValue = value; } }

    public Dice(string name, int face, string[] typeFace, string[] faceValue)
    {
        Name = name;
        Face = face;
        TypeFace = typeFace;
        FaceValue = faceValue;
    }
    public string GetResult()
    {
        var rand = new System.Random();

        int i = rand.Next(face);
        string res = typeFace[i];
        res += ':';
        res += faceValue[i];
        return res;
    }

    public byte[] ToByteArray()
    {
        byte[] nameArray = Encoding.ASCII.GetBytes(name);
        int nbByteName = nameArray.Length;

        byte[] faceArray = BitConverter.GetBytes(face);

        int[] nbByteType = new int[face];
        int[] nbByteValue = new int[face];

        byte[][] type = new byte[face][];
        byte[][] value = new byte[face][];
        int nbByteValueTotal = 0;
        int nbByteTypeTotal = 0;
        for (int i = 0; i < face; i++)
        {
            type[i] = Encoding.ASCII.GetBytes(typeFace[i]);
            value[i] = Encoding.ASCII.GetBytes(faceValue[i]);

            nbByteType[i] = type[i].Length;
            nbByteValue[i] = value[i].Length;

            nbByteValueTotal += value[i].Length;
            nbByteTypeTotal += type[i].Length;
        }
        int totalLength = nbByteName + nbByteTypeTotal + nbByteValueTotal + (4 * 4 + 4*face*2);// nbByteName + nbByteType + nbByteValue + faceArray + nb int * 2*face
        byte[] res = AddArray(BitConverter.GetBytes(nbByteName),nameArray);


        res = AddArray(res,faceArray);
        for (int i = 0; i < face; i++)
        {
            res = AddArray(res, BitConverter.GetBytes(nbByteType[i]));
            res = AddArray(res, type[i]);


            res = AddArray(res, BitConverter.GetBytes(nbByteValue[i]));
            res = AddArray(res, value[i]);
        }
        return res;
    }

    public override string ToString()
    {
        string res = "name : " + name + '\n';
        res += " nb face : " + face + "\n"; 
        for (int i = 0; i < face; i++)
        {
            res += "type : " + typeFace[i] + " | value : " + faceValue[i] + "\n";
        }
        return res;
    }
    public static Dice GetDiceFromByte(byte[] array)
    {
        int streamCount = 0;
        int nbByteName = BitConverter.ToInt32(array,streamCount);
        streamCount += 4;
        string name = StringFromByte(Split(array, streamCount, streamCount += nbByteName));
        int face = BitConverter.ToInt32(array,streamCount);
        streamCount += 4;
        int nbByte = 0;

        string[] type = new string[face];
        string[] value = new string[face];
        for (int i = 0; i < face; i++)
        {
            nbByte = BitConverter.ToInt32(array, streamCount);
            streamCount += 4;

            type[i] = StringFromByte(Split(array, streamCount, streamCount += nbByte));
            nbByte = BitConverter.ToInt32(array, streamCount);
            streamCount += 4;
            value[i] = StringFromByte(Split(array, streamCount, streamCount += nbByte));
        }

        return new Dice(name, face, type, value);
    }

    public static string StringFromByte(byte[] array)
    {
        return Encoding.Default.GetString(array);
    }
    public static byte[] Split(byte[] byteArray, int start,int end)
    {
        byte[] res = new byte[end-start];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = byteArray[start + i];
        }
        return res;
    }
    public static byte[] AddArray(byte[] array1, byte[] array2)
    {

        byte[] res = new byte[array1.Length + array2.Length];
        for (int i = 0; i <array1.Length; i++)
        {
            res[i] = array1[i];
        }
        for (int i = 0; i < array2.Length; i++)
        {
            res[array1.Length + i] = array2[i];
        }
        return res;
    }
  
}
