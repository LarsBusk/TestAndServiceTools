using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RemovePmsFromFi
{
    public class XmlHelper
    {
        public string[] UsedProducts;

        private string _pathToSysData;
        private readonly string _pathToComData;

        private XDocument _sysDoc;
        private XDocument _comDoc;

        public XmlHelper(string pathToData)
        {
            _pathToSysData = Path.Combine(pathToData, "Data", "System.xml");
            _pathToComData = Path.Combine(pathToData, "Data", "ComponentData.xml");
        }

        public void RemoveProductsFromSysXml()
        {
            GetSysDoc();
            var settingsElement = _sysDoc.Element("tSettings");
            var productElements = settingsElement?.Element("tMeasureProfileList")?.Elements("tMeasureProfile");
            var products = productElements.Select(e => e.Attribute("sName")?.Value).ToList();

            var productsToRemove = products.Where(p => !UsedProducts.Contains(p)).ToList();

            var productElementsToRemove =
                productElements.Where(pe =>
                    productsToRemove.Contains(pe.Attribute("sName").Value)).ToList();

            var productNames = productElementsToRemove.Select(p => p.Attribute("sName").Value).ToList();

            var form = new ProductsForm()
            {
                Products = productNames,
                Message = "These products are not used in any result. Select the one to remove.",
                ButtonText = "Remove"
            };

            if (form.ShowDialog().Equals(DialogResult.Cancel))
                return;

            productElementsToRemove =
                productElementsToRemove.Where(p => form.Products.Contains(p.Attribute("sName").Value)).ToList();

            foreach (var xElement in productElementsToRemove)
            {
                xElement.Remove();
            }

            SaveSysDoc();
        }

        public void RemovePmsFromSysXml()
        {
            var usedPms = PmsUsedInProducts();
            GetSysDoc();
            var allPms = _sysDoc.Element("tSettings").Element("tComponentList").Elements("tComponent");
            var pmsToRemove = allPms.Where(p => !usedPms.Contains(p.Attribute("ID").Value)).ToList();

            var form = new ProductsForm()
            {
                Products = PmNames(pmsToRemove),
                Message = "These PMs are not used, select the ones to be removed.",
                ButtonText = "Remove"
            };

            if(form.ShowDialog().Equals(DialogResult.Cancel))
                return;

            var pmGuids = PmGuids(form.Products);

            pmsToRemove = pmsToRemove.Where(p => pmGuids.Contains(p.Attribute("ID").Value)).ToList();

            foreach (var xElement in pmsToRemove)
            {
                xElement.Remove();
            }

            SaveSysDoc();
        }

        public void RemoveUnusedComponentsFromCom()
        {
            var allComps = PmsInComponents();
            var usedComps = PmsUsedInProducts();
            var compsToRemove = allComps.Where(c => !usedComps.Contains(c)).ToList();

            GetComDoc();
            var componentElements = _comDoc.Root.Element("tComponentList").Elements("tComponent").ToList();

            var componentsToRemove = componentElements.Where(e =>
                compsToRemove.Contains(e.Attribute("ID").Value)).ToList();

            foreach (var xElement in componentsToRemove)
            {
                FiHelper.DeleteMccFile(xElement);
                xElement.Remove();
            }

            SaveComDoc();
        }

        private IEnumerable<string> PmsUsedInProducts()
        {
            GetSysDoc();
            var settingsElement = _sysDoc.Element("tSettings");
            var productElements = settingsElement.Element("tMeasureProfileList").Elements("tMeasureProfile");
            var pmLists = productElements.Select(e =>
                e.Element("tMeasureProfileComponentList"));
            var pMs = pmLists.Elements("tMeasureProfileComponent").Select(e => e.Attribute("ID").Value).Distinct();
            return pMs;
        }

        private IEnumerable<string> PmsInComponents()
        {
            var componentList = ComponentElements();
            return componentList.Select(c => c.Attribute("ID").Value);
        }

        private List<XElement> ComponentElements()
        {
            GetComDoc();
            var components = _comDoc.Root.Element("tComponentList").Elements("tComponent")
                .Where(c => c.Element("eComponentType").Value.Equals("::MEASURED")).ToList();
            return components;
        }

        private List<string> PmNames(List<XElement> pmElements)
        {
            var pmGuids = pmElements.Select(p => p.Attribute("ID").Value);
            var allComponentElements = ComponentElements();
            var pms = allComponentElements.Where(e => pmGuids.Contains(e.Attribute("ID").Value));

            var names = pms.Select(p => p.Element("sName").Value).ToList();

            return names;
        }

        private List<string> PmGuids(IEnumerable<string> pmNames)
        {
            var pmElements = ComponentElements().Where(p => pmNames.Contains(p.Element("sName").Value));
            var guids = pmElements.Select(e => e.Attribute("ID").Value);

            return guids.ToList();
        }

        private void GetSysDoc()
        {
            _sysDoc = XDocument.Load(_pathToSysData);
        }

        private void GetComDoc()
        {
            _comDoc = XDocument.Load(_pathToComData);
        }

        private void SaveSysDoc()
        {
            var writer = new Utf8StringWriter();
            _sysDoc.Save(writer);
            File.WriteAllText(_pathToSysData, writer.ToString());
        }

        private void SaveComDoc()
        {
            var writer = new Utf8StringWriter();
            _comDoc.Save(writer);
            File.WriteAllText(_pathToComData, writer.ToString());
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
