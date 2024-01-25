namespace DexterOpcUaTestServer.States
{
    public class StateDexterMeasuring : IState
    {
        public string StateName => "Measuring";
        private OpcUaHelper helper;

        public StateDexterMeasuring(OpcUaHelper opcUaHelper)
        {
            helper = opcUaHelper;
            var currentProduct = helper.Nodes.InstrumentNodes.ProductName.Value;
            //helper.StartMeasuring(currentProduct);
        }

        public void ChangeProduct(string product)
        {
            helper.ChangeProduct(product);
        }

        public void ChangeRecipe(string recipe) { }

        public void OpenSettings()
        {
        }

        public void StartStopMeasuring(string product)
        {
            helper.StopMeasuring();
        }


        public void StartServer()
        {
        }


        public void StopServer()
        {
            helper.StopServer();
        }
    }
}
