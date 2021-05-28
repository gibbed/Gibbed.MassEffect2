namespace Gibbed.MassEffect2.SaveEdit
{
    internal class Plot
    {
        public int Id;
        public string Name;
        public bool Legacy;

        public Plot(int id, string name, bool legacy)
        {
            this.Id = id;
            this.Name = name;
            this.Legacy = legacy;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
