using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyTracker.BusinessLogic
{
    public class Floor
    {
        public Floor(FloorEnum level, Bitmap image, float min, float max, float topLeftX, float topLeftZ)
        {
            Level = level;
            Image = image;
            SwapHeightMin = min;
            SwapHeightMax = max;
            TopLeftX = topLeftX;
            TopLeftZ = topLeftZ;
        }

        public float TopLeftX { get; set; }
        public float TopLeftZ { get; set; }
        public float SwapHeightMin { get; set; }
        public float SwapHeightMax { get; set; }
        public FloorEnum Level { get; set; }
        public Bitmap Image { get; set; }
    }
}
