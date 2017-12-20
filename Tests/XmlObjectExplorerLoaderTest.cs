using System;
using SqlEasyStudio.Persistance;
using SqlEasyStudio.Persistance.Exceptions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XmlObjectExplorerLoaderTest
    {
        [Test]
        public void Load()
        {
            Assert.Throws<InvalidConfigurationException>(() => { (new XmlObjectExplorerRepository("")).Load(); });
            Assert.Throws<InvalidConfigurationException>(() => { (new XmlObjectExplorerRepository("sd")).Load(); });
        }
    }
}
