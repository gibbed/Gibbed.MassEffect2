using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE5B0
    public class PlotTable : IUnrealSerializable
    {
        public List<int> BoolVariables; // +00  ... maybe needs to be List<int>
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
    }
}
