using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM3_Proto;
using System.Windows.Controls;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CheckBox checkBox = new CheckBox();
            Button button1 = new Button();
            LinkData linkData = new LinkData(checkBox, 1, 1, 1, LinkData.LinkDirection.BI, button1);

            Assert.AreEqual(linkData.BSID,1);
            Assert.AreEqual(linkData.MSID, 1);
        }

        [TestMethod]
        public void RangeCheck()
        {
            CheckBox checkBox = new CheckBox();
            Button button1 = new Button();
            LinkData linkData = new LinkData(checkBox, 17, 1, 1, LinkData.LinkDirection.DL, button1);

            Assert.AreNotEqual(linkData.LinkID, 17);
            Assert.AreEqual(linkData.MSID, 1);
        }

        [TestMethod]
        public void LinkDataVMCheckNumLinks()
        {
            MainWindow mainWindow = new MainWindow();
            
            Links links = new Links();

            Assert.AreEqual(links.DataSource.DataItems.Count, 16);
        }
    }


}
