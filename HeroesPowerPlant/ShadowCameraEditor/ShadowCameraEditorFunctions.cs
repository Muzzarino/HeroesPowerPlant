﻿using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;

namespace HeroesPowerPlant.ShadowCameraEditor
{
    public static class ShadowCameraEditorFunctions
    {
        public static Tuple<byte[], List<ShadowCamera>> ImportCameraFile(string fileName)
        {
            List<ShadowCamera> list = new List<ShadowCamera>();
            byte[] headerArray;
            using (BinaryReader camReader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                camReader.BaseStream.Position = 0;
                headerArray = camReader.ReadBytes(0x18);

                while (camReader.BaseStream.Position != camReader.BaseStream.Length)
                {
                    ShadowCamera TempCam = new ShadowCamera(
                        camReader.ReadInt32(), //i_00
                        camReader.ReadInt32(),
                        camReader.ReadInt32(),
                        camReader.ReadInt32(),
                        camReader.ReadInt32(),
                        camReader.ReadInt32(),
                        camReader.ReadInt32(),
                        camReader.ReadInt32(), //i_1C
                        new Vector3(camReader.ReadSingle(), camReader.ReadSingle(), camReader.ReadSingle()),
                        new Vector3(camReader.ReadSingle(), camReader.ReadSingle(), camReader.ReadSingle()),
                        new Vector3(camReader.ReadSingle(), camReader.ReadSingle(), camReader.ReadSingle()),
                        camReader.ReadSingle(), //i_44
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //i_58
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //60
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //70
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //80
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //90
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //A0
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //B0
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //C0
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(),
                        camReader.ReadSingle(), //D0
                        camReader.ReadSingle(),
                        camReader.ReadSingle()
                    );

                    //if (TempCam.CameraType == 0 & TempCam.CameraSpeed == 0 & TempCam.Integer3 == 0 & TempCam.ActivationType == 0 & TempCam.TriggerShape == 0)
                     //   continue;

                    TempCam.CreateTransformMatrix();

                    list.Add(TempCam);
                }
            }
            return Tuple.Create(headerArray, list);
        }

        public static void SaveCameraFile(string fileName, byte[] headerArray, IEnumerable<ShadowCamera> list)
        {
            BinaryWriter CameraWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create));

            CameraWriter.Write(headerArray);

            foreach (ShadowCamera i in list)
            {
                CameraWriter.Write(i.field_00);
                CameraWriter.Write(i.field_04);
                CameraWriter.Write(i.field_08);
                CameraWriter.Write(i.field_0C);
                CameraWriter.Write(i.field_10);
                CameraWriter.Write(i.field_14);
                CameraWriter.Write(i.field_18);
                CameraWriter.Write(i.field_1C);
                CameraWriter.Write(i.TriggerPosition.X);
                CameraWriter.Write(i.TriggerPosition.Y);
                CameraWriter.Write(i.TriggerPosition.Z);
                CameraWriter.Write(i.TriggerRotation.X);
                CameraWriter.Write(i.TriggerRotation.Y);
                CameraWriter.Write(i.TriggerRotation.Z);
                CameraWriter.Write(i.TriggerScale.X);
                CameraWriter.Write(i.TriggerScale.Y);
                CameraWriter.Write(i.TriggerScale.Z);
                CameraWriter.Write(i.field_44);
                CameraWriter.Write(i.field_48);
                CameraWriter.Write(i.field_4C);
                CameraWriter.Write(i.field_50);
                CameraWriter.Write(i.field_54);
                CameraWriter.Write(i.field_58);
                CameraWriter.Write(i.field_5C);
                CameraWriter.Write(i.field_60);
                CameraWriter.Write(i.field_64);
                CameraWriter.Write(i.field_68);
                CameraWriter.Write(i.field_6C);
                CameraWriter.Write(i.field_70);
                CameraWriter.Write(i.field_74);
                CameraWriter.Write(i.field_78);
                CameraWriter.Write(i.field_7C);
                CameraWriter.Write(i.field_80);
                CameraWriter.Write(i.field_84);
                CameraWriter.Write(i.field_88);
                CameraWriter.Write(i.field_8C);
                CameraWriter.Write(i.field_90);
                CameraWriter.Write(i.field_94);
                CameraWriter.Write(i.field_98);
                CameraWriter.Write(i.field_9C);
                CameraWriter.Write(i.field_A0);
                CameraWriter.Write(i.field_A4);
                CameraWriter.Write(i.field_A8);
                CameraWriter.Write(i.field_AC);
                CameraWriter.Write(i.TransitionTimeEnter);
                CameraWriter.Write(i.TransitionTimeExit);
                CameraWriter.Write(i.field_B8);
                CameraWriter.Write(i.field_BC);
                CameraWriter.Write(i.field_C0);
                CameraWriter.Write(i.field_C4);
                CameraWriter.Write(i.field_C8);
                CameraWriter.Write(i.field_CC);
                CameraWriter.Write(i.field_D0);
                CameraWriter.Write(i.field_D4);
                CameraWriter.Write(i.field_D8);
            }
            CameraWriter.Close();
        }
    }
}
