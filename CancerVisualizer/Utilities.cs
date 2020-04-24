using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CancerVisualizer
{
    public static class Utilities
    {
        public static List<int[]> LoadSuggestedPoints(string wsi_name)
        {
            List<int[]> suggestedPoints = new List<int[]>();
            string path = ExplanationDatabase.WSI_DATA_PATH + wsi_name;
            string fileName = $"\\suggested_points_{wsi_name}.txt";
            string[] lines = System.IO.File.ReadAllLines(path + fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                var parsedLine = lines[i].Split(',');
                Int32.TryParse(parsedLine[0], out int x);
                Int32.TryParse(parsedLine[1], out int y);
                Int32.TryParse(parsedLine[2], out int flag);
                if(flag == 1 || flag == 2)
                    suggestedPoints.Add(new int[] { x, y, flag });
            }

            return suggestedPoints;
        }

        /// <summary>
        /// from 5000x5000x8 array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <param name="idx3"></param>
        /// <returns></returns>
       public static sbyte getProb(sbyte[][] array, int idx1, int idx2, int idx3)
        {
            var row = array[idx2];
            int idx = idx1 + idx3 * 5000;
            return row[idx];
        }

        public static sbyte[] getProbVector(sbyte[][] array, int idx1, int idx2)
        {
            sbyte[] vector = new sbyte[8];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = getProb(array, idx1, idx2, i);
            }

            return vector;
        }

        public static void HighlightWords(string[] words, RichTextBox rich)
        {
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < rich.TextLength)
                {

                    int wordStartIndex = rich.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex != -1)
                    {
                        rich.SelectionStart = wordStartIndex;
                        rich.SelectionLength = word.Length;
                        var myKey = ExplanationDatabase.classes.FirstOrDefault(x => x.Value == word).Key;
                        rich.SelectionBackColor = ExplanationDatabase.colorsRGB[myKey-1];
                        rich.SelectionColor = Color.White;
                        if(myKey == 3) rich.SelectionColor = Color.Black;
                    }
                    else
                        break;
                    startIndex += wordStartIndex + word.Length;
                }
            }

            rich.SelectAll();
            // Changes the font size to 11pt if some text is selected
            rich.SelectionFont = new System.Drawing.Font(
                rich.SelectionFont.FontFamily.Name,
                12F,
                rich.SelectionFont.Style,
                System.Drawing.GraphicsUnit.Point,
                ((byte)(0)));
        }

        public static int[] GetAbsolutCoordinates(Point coordinates, int ORIGINAL_SIZE, PictureBox pcBx_cancer)
        {
            int x = coordinates.X;
            int y = coordinates.Y;

            double act_scale = (double)ORIGINAL_SIZE / (double)pcBx_cancer.Width;
            int xx = (int)(x * act_scale);
            int yy = (int)(y * act_scale);

            return new int[] { xx, yy };
        }

        public static int[] GetRelativeCoordinates(int x, int y, int ORIGINAL_SIZE, PictureBox pcBx_cancer)
        {

            double act_scale = (double)ORIGINAL_SIZE / (double)pcBx_cancer.Width;
            int xx = (int)(x / act_scale);
            int yy = (int)(y / act_scale);

            return new int[] { xx, yy };
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
