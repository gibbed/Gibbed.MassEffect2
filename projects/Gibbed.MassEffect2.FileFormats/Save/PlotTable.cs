/* Copyright (c) 2021 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE5B0
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PlotTable : IUnrealSerializable
    {
        public BitArray BoolVariables; // +00
        public List<int> IntVariables; // +0C
        public List<float> FloatVariables; // +18
        public int QuestProgressCounter; // +24
        public List<PlotQuest> QuestProgress; // +28
        public List<int> QuestIDs; // +34
        public List<PlotCodex> CodexEntries; // +40
        public List<int> CodexIDs; // +4C

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.BoolVariables);
            stream.Serialize(ref this.IntVariables);
            stream.Serialize(ref this.FloatVariables);
            stream.Serialize(ref this.QuestProgressCounter);
            stream.Serialize(ref this.QuestProgress);
            stream.Serialize(ref this.QuestIDs);
            stream.Serialize(ref this.CodexEntries);
            stream.Serialize(ref this.CodexIDs);
        }

        [DisplayName("Paragon Points")]
        public int _helper_ParagonPoints
        {
            get { return this.GetIntVariable(2); }
            set { this.SetIntVariable(2, value); }
        }

        [DisplayName("Renegade Points")]
        public int _helper_RenegadePoints
        {
            get { return this.GetIntVariable(3); }
            set { this.SetIntVariable(3, value); }
        }

        public bool GetBoolVariable(int index)
        {
            if (index >= this.BoolVariables.Count)
            {
                return false;
            }

            return this.BoolVariables[index];
        }

        public void SetBoolVariable(int index, bool value)
        {
            if (index >= this.BoolVariables.Count)
            {
                this.BoolVariables.Length = index + 1;
            }

            this.BoolVariables[index] = value;
        }

        public int GetIntVariable(int index)
        {
            if (index >= this.IntVariables.Count)
            {
                return 0;
            }

            return this.IntVariables[index];
        }

        public void SetIntVariable(int index, int value)
        {
            if (index >= this.IntVariables.Count)
            {
                this.IntVariables.Capacity = index + 1;
            }

            this.IntVariables[index] = value;
        }

        public float GetFloatVariable(int index)
        {
            if (index >= this.FloatVariables.Count)
            {
                return 0;
            }

            return this.FloatVariables[index];
        }

        public void SetFloatVariable(int index, float value)
        {
            if (index >= this.IntVariables.Count)
            {
                this.IntVariables.Capacity = index + 1;
            }

            this.FloatVariables[index] = value;
        }
    }
}
