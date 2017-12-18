using System;
using SqlEasyStudio.Filesystem;
using SqlEasyStudio.Filesystem.Exceptions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XmlObjectExplorerLoaderTest
    {
        [Test]
        public void Load()
        {
            Assert.Throws<InvalidConfigurationException>(() => { (new XmlObjectExplorerLoader("")).Load(); });
            Assert.Throws<InvalidConfigurationException>(() => { (new XmlObjectExplorerLoader("sd")).Load(); });
        }
    }
}
