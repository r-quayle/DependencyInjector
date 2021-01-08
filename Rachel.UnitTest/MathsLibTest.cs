using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rachel.Maths.Interface;

namespace Rachel.UnitTest
{
    [TestClass]
    public class MathsLibTest
    {
        IMathsLib _mathsLib;
        [TestInitialize]
        public void init()
        {
            DependencyInjector.Container diContainer = new DependencyInjector.Container();
            diContainer.Load(new List<DependencyInjector.DIModule> { new Rachel.Maths.DependencyInjector.MathsLibModule() });
            _mathsLib = diContainer.Get<IMathsLib>();
        }
        [TestMethod]
        public void NegativeHitTest()
        {
            bool actual = _mathsLib.IsInCircle(new Maths.Coords { X = 0, Y = 0 });
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PositiveHitTest()
        {
            bool actual = _mathsLib.IsInCircle(new Maths.Coords { X = _mathsLib.Square.X / 2, Y = _mathsLib.Square.Y / 2 });
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EdgeHitTest1()
        {
            bool actual = _mathsLib.IsInCircle(new Maths.Coords { X = 0, Y = _mathsLib.Square.Y / 2 });
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EdgeHitTest2()
        {
            bool actual = _mathsLib.IsInCircle(new Maths.Coords { X = _mathsLib.Square.X / 2, Y = 0 });
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
