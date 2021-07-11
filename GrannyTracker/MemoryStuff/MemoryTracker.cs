using GrannyTracker.BusinessLogic;
using MemoryStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrannyTracker.MemoryStuff
{
    class MemoryTracker
    {
        public String DebugMessage { get; set; }

        private static readonly uint GrannyPosOffset1 = 0x01692F18;
        private static readonly uint GrannyPosOffset2 = 0x8;
        private static readonly uint GrannyPosOffset3 = 0x70;
        private static readonly uint GrannyPosX = 0xB0;
        private static readonly uint GrannyPosY = GrannyPosX + 0x4;
        private static readonly uint GrannyPosZ = GrannyPosY + 0x4;

        private static MemoryTracker instance;

        private Memory GameMemory { get; set; }
        private System.Threading.Timer UpdateTimer { get; set; }

        public float GrannyX { get; private set; }
        public float GrannyY { get; private set; }
        public float GrannyZ { get; private set; }

        public static MemoryTracker Instance
        {
            get
            {
                if (instance == null)
                    instance = new MemoryTracker();

                return instance;
            }
        }

        private MemoryTracker()
        {
            GameMemory = new Memory("Granny", "UnityPlayer.dll");
        }

        public void StartTimer()
        {
            UpdateTimer = new System.Threading.Timer(new TimerCallback(this.Update), null, 100, 100);
        }

        public void StopTimer()
        {
            UpdateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Update(Object stateInfo)
        {
            DebugMessage = "Base Addr: " + GameMemory.getBaseAddress();
            UInt64 grannyPos1 = GameMemory.Read<UInt64>(GameMemory.getBaseAddress() + GrannyPosOffset1);
            if (grannyPos1 == 0)
            {
                DebugMessage += "\n grannyPos1 was 0";
                return;
            }
            UInt64 grannyPos2 = GameMemory.Read<UInt64>(grannyPos1 + GrannyPosOffset2);
            if (grannyPos2 == 0)
            {
                DebugMessage += "\n grannyPos2 was 0";
                return;
            }

            UInt64 grannyPos3 = GameMemory.Read<UInt64>(grannyPos2 + GrannyPosOffset3);
            if (grannyPos3 == 0)
            {
                DebugMessage += "\n grannyPos3 was 0";
                return;
            }

            GrannyX = GameMemory.Read<float>(grannyPos3 + GrannyPosX);
            GrannyY = GameMemory.Read<float>(grannyPos3 + GrannyPosY);
            GrannyZ = GameMemory.Read<float>(grannyPos3 + GrannyPosZ);


            DebugMessage += "\n " + GrannyX + " " + GrannyY + " " + GrannyZ;
        }



    }
}
