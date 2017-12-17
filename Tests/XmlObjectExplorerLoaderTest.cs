using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlEasyStudio.Filesystem;
using SqlEasyStudio.Filesystem.Exceptions;

namespace Tests
{
    [TestClass]
    public class XmlObjectExplorerLoaderTest
    {
        [TestMethod]
        public void Load()
        {
            Assert.ThrowsException<InvalidConfigurationException>(() => { (new XmlObjectExplorerLoader("")).Load(); });
            Assert.ThrowsException<InvalidConfigurationException>(() => { (new XmlObjectExplorerLoader("sd")).Load(); });            
        }
    }
}
