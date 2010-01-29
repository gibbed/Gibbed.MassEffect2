using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE040
    public class ME1PlotTable : IUnrealSerializable
    {
        public List<int> BoolVariables; // +00  ... maybe needs to be List<int>
        public List<int> IntVariables; // +0C
        public List<float> FloatVariables; // +18

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.BoolVariables);
            stream.Serialize(ref this.IntVariables);
            stream.Serialize(ref this.FloatVariables);
        }
    }
}
