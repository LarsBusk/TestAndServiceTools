namespace NoraJitterTool
{
    public class TestSystemComboItem
    {
        public string Name { get; set; }
        public decimal ChassisId { get; set; }

        public TestSystemComboItem(string name, decimal chassisId)
        {
            this.Name = name;
            this.ChassisId = chassisId;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
