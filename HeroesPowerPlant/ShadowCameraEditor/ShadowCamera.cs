﻿using SharpDX;

namespace HeroesPowerPlant.ShadowCameraEditor {
 /*     // HEADER : SIZE=0x18
        0x0 = magic
        0x4 = magic
        0x8 = stageID int
        0xC =
        0x10 =
        0x14 = NumberOfCameras int

        //CAMERA : SIZE=0xDC
        0x0 - 0x18 = Unknown
        0x1C = CameraAffectSpeed int
        0x20 - 0x2B = TriggerPosition Vector3
        0x2C - 0x37 = Unknown
        0x38 - 0x43 = TriggerScale Vector3
 */
    public class ShadowCamera {
        public byte[] UnknownSection1;
        public Vector3 TriggerPosition;
        public byte[] UnknownSection2;
        public Vector3 TriggerScale;
        public byte[] UnknownSection3;

        /*
        public int CameraType;
        public int CameraSpeed;
        public int Integer3;
        public int ActivationType;
        public int TriggerShape;
        public Vector3 TriggerPosition;
        public int TriggerRotX;
        public int TriggerRotY;
        public int TriggerRotZ;
        public Vector3 TriggerScale;
        public Vector3 CamPos;
        public int CamRotX;
        public int CamRotY;
        public int CamRotZ;
        public Vector3 PointA;
        public Vector3 PointB;
        public Vector3 PointC;
        public int Integer30;
        public int Integer31;
        public float FloatX32;
        public float FloatY33;
        public float FloatX34;
        public float FloatY35;
        public int Integer36;
        public int Integer37;
        public int Integer38;
        public int Integer39;*/

        public ShadowCamera(byte[] sec1, Vector3 triggerPos, byte[] sec2, Vector3 triggerScale, byte[] sec3) {
            UnknownSection1 = sec1;
            TriggerPosition = triggerPos;
            UnknownSection2 = sec2;
            TriggerScale = triggerScale;
            UnknownSection3 = sec3;
        }
    }
}