using Controllers;
using Models;
using NUnit.Framework;

namespace Tests {
    public class LayoutLoadingTest {
        private LayoutLoader _data;
        [SetUp]
        public void Init() {
            _data = new LayoutLoader();
            _data.Getlayout();
        }

        [Test]
        public void ReturnsLayoutObject() {
            Assert.AreEqual(typeof(Layout), _data.BoardLayout.GetType());
        }

        [Test]
        public void ReturnsLayoutHeight() {
            Assert.Greater(_data.BoardLayout.height, 0);
        }
        
        [Test]
        public void ReturnsLayoutWidth() {
            Assert.Greater(_data.BoardLayout.width, 0);
        }

    }
}