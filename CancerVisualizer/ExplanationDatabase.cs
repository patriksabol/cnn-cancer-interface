using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerVisualizer
{
    public static class ExplanationDatabase
    {
        private static string WSI_PATH = "C:\\Users\\CitLat_Sabol\\Documents\\School\\Image_data\\" +
                "Kather_texture_2016_larger_images_10\\";
        public static string[] wsi_paths =
        {
            WSI_PATH+"CRC-Prim-HE-01_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-02_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-03_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-04_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-05_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-06_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-07_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-08_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-09_APPLICATION.tif",
            WSI_PATH+"CRC-Prim-HE-10_APPLICATION.tif"
        };
        

        public static string WSI_DATA_PATH = "C:\\Users\\CitLat_Sabol\\Documents\\School\\Image_data\\results_WSI_data\\";
        public static string[] wsi_labels_paths =
        {
            WSI_DATA_PATH+"WSI_01\\labelMap_CNN_WSI_01.tif",
            WSI_DATA_PATH+"WSI_02\\labelMap_CNN_WSI_02.tif",
            WSI_DATA_PATH+"WSI_03\\labelMap_CNN_WSI_03.tif",
            WSI_DATA_PATH+"WSI_04\\labelMap_CNN_WSI_04.tif",
            WSI_DATA_PATH+"WSI_05\\labelMap_CNN_WSI_05.tif",
            WSI_DATA_PATH+"WSI_06\\labelMap_CNN_WSI_06.tif",
            WSI_DATA_PATH+"WSI_07\\labelMap_CNN_WSI_07.tif",
            WSI_DATA_PATH+"WSI_08\\labelMap_CNN_WSI_08.tif",
            WSI_DATA_PATH+"WSI_09\\labelMap_CNN_WSI_09.tif",
            WSI_DATA_PATH+"WSI_10\\labelMap_CNN_WSI_10.tif"
        };
                

        public static string[] wsi_probabilities_path =
        {
            WSI_DATA_PATH+"WSI_01\\probabilities_CNN_WSI_01.bin",
            WSI_DATA_PATH+"WSI_02\\probabilities_CNN_WSI_02.bin",
            WSI_DATA_PATH+"WSI_03\\probabilities_CNN_WSI_03.bin",
            WSI_DATA_PATH+"WSI_04\\probabilities_CNN_WSI_04.bin",
            WSI_DATA_PATH+"WSI_05\\probabilities_CNN_WSI_05.bin",
            WSI_DATA_PATH+"WSI_06\\probabilities_CNN_WSI_06.bin",
            WSI_DATA_PATH+"WSI_07\\probabilities_CNN_WSI_07.bin",
            WSI_DATA_PATH+"WSI_08\\probabilities_CNN_WSI_08.bin",
            WSI_DATA_PATH+"WSI_09\\probabilities_CNN_WSI_09.bin",
            WSI_DATA_PATH+"WSI_10\\probabilities_CNN_WSI_10.bin",

        };

        private static double[,] colors = new double[,]
            { {1 ,0, 0 },{0, 1, 0 },{1, 1, 0 },{0, 0, 1},{1, 0, 1},{1, 0.71, 0.75}, {0.5, 0.5, 0.5},{0, 0, 0}};

        public static Color[] colorsRGB = new Color[]
            {
                Color.FromArgb(255,0,0),
                Color.FromArgb(0,255,0),
                Color.FromArgb(255,255,0),
                Color.FromArgb(0,0,255),
                Color.FromArgb(255,0,255),
                Color.FromArgb(255,181,191),
                Color.FromArgb(127,127,127),
                Color.FromArgb(0,0,0),
            };

        public static int GetLabel(Color col)
        {
            for (int i = 0; i < colorsRGB.Length; i++)
            {
                if (colorsRGB[i].Equals(col))
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public static string data_memberships_path = "C:\\Users\\CitLat_Sabol\\Documents\\School\\" +
            "Image_data\\results_WSI_data\\memberships_whole_dataset.bin";
        public static string data_paths = "C:\\Users\\CitLat_Sabol\\Documents\\School\\" +
            "Image_data\\results_WSI_data\\trainingData_list.txt";

        public static Dictionary<int, string> classes = new Dictionary<int, string>
        {
            {0, "nešpecifikované" },
            {1,"Tumour epithelum" },
            {2,"Simple stroma" },
            {3,"Complex stroma" },
            {4,"Immune cells" },
            {5,"Debris or mucus" },
            {6,"Mucosal glands" },
            {7,"Adipose tissue" },
            {8,"Background" }
        };

        public static ExperimentsNames[] experimentsNames = new ExperimentsNames[]
        {
            new ExperimentsNames("WSI_01", 0),
            new ExperimentsNames("WSI_02", 1),
            new ExperimentsNames("WSI_03", 2),
            new ExperimentsNames("WSI_04", 3),
            new ExperimentsNames("WSI_05", 4),
            new ExperimentsNames("WSI_06", 5),
            new ExperimentsNames("WSI_07", 6),
            new ExperimentsNames("WSI_08", 7),
            new ExperimentsNames("WSI_09", 8),
            new ExperimentsNames("WSI_10", 9)
        };



    }

    public struct ExperimentsNames
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public ExperimentsNames(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
