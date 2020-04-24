using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerVisualizer
{
    public static class LoadDatabase
    {
        public static byte[,,] Load_Png_Array(string path)
        {
            Image<Gray, Byte> img = new Image<Gray, Byte>(path);
            return img.Data;
        }

        public static byte[] LoadProbabilities(int index)
        {
            var b = File.ReadAllBytes(ExplanationDatabase.wsi_probabilities_path[index]);

            return b;
        }

        public static float[] GetProbabilityVector(byte[] probabilities, int x, int y)
        {
            float[] vector = new float[8];
            for (int k = 0; k < 8; k++)
            {
                int a = y + x * 5000 + k * 5000 * 5000;
                vector[k] = System.BitConverter.ToSingle(probabilities, a * 4);
            }

            return vector;
        }

    }
}
