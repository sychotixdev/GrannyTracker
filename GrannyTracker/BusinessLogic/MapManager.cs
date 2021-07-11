using GrannyTracker.MemoryStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrannyTracker.BusinessLogic
{
    class MapManager
    {
        private static MapManager instance;

        private Floor displayedFloor { get; set; }

        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MapManager();

                return instance;
            }
        }

        List<Floor> floors { get; set; }

        private MapManager()
        {
           floors = new List<Floor>
            {
                new Floor(FloorEnum.Floor2, Properties.Resources.floor2, 18, 22, -20.7465f, 13.122f),
                new Floor(FloorEnum.Floor1, Properties.Resources.floor1, 10.5f, 14, -20.7612f, 13.1118f)
            };

        }

        public void UpdatePictureMap(PictureBox pictureBox, Graphics g, RichTextBox richTextBox)
        {
            float yCoord = MemoryTracker.Instance.GrannyY;

            // First, hunt through our floors
            Floor herFloor = floors.FirstOrDefault(x => x.SwapHeightMax >= yCoord && x.SwapHeightMin <= yCoord);

            // Just default a floor, it really doesn't matter. She should move off the stairs at some point
            if (herFloor == null)
                herFloor = floors.ElementAt(0);

            if (displayedFloor == null || herFloor.Level != displayedFloor.Level)
            {
                pictureBox.Image = herFloor.Image;
                displayedFloor = herFloor;
            }

            // Draw a rectable in the PictureBox.
            int calculatedX = (int)((MemoryTracker.Instance.GrannyX - displayedFloor.TopLeftX) * 10);
            int calculatedZ = -1 * (int)((MemoryTracker.Instance.GrannyZ - displayedFloor.TopLeftZ) * 10);


            float grannyFaceWidth = 13.08f;
            float grannyFaceHeight = 15f;

            g.DrawImage(Properties.Resources.GrannyFace, calculatedX - grannyFaceWidth / 2, calculatedZ - grannyFaceHeight / 2, grannyFaceWidth, grannyFaceHeight);

            richTextBox.Text = MemoryTracker.Instance.DebugMessage + " calcX " + calculatedX + " calcZ " + calculatedZ;
        }
    }
}
